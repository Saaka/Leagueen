using Leagueen.Application.Competitions.Events;
using Leagueen.Application.Competitions.Repositories;
using Leagueen.Application.DataProviders;
using Leagueen.Application.DataProviders.Competitions;
using Leagueen.Application.Matches.Commands;
using Leagueen.Domain.Entities;
using Leagueen.Domain.Exceptions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Competitions.Commands.InitializeCompetitionCurrentSeason
{
    public class InitializeCompetitionCurrentSeasonCommandHandler : AsyncRequestHandler<InitializeCompetitionCurrentSeasonCommand>
    {
        private readonly ICompetitionsProvider competitionsProvider;
        private readonly ISeasonsRepository seasonsRepository;
        private readonly ICompetitionsRepository competitionsRepository;
        private readonly ITeamsRepository teamsRepository;
        private readonly IMediator mediator;

        public InitializeCompetitionCurrentSeasonCommandHandler(
            ICompetitionsProvider competitionsProvider,
            ISeasonsRepository seasonsRepository,
            ICompetitionsRepository competitionsRepository,
            ITeamsRepository teamsRepository,
            IMediator mediator)
        {
            this.competitionsProvider = competitionsProvider;
            this.seasonsRepository = seasonsRepository;
            this.competitionsRepository = competitionsRepository;
            this.teamsRepository = teamsRepository;
            this.mediator = mediator;
        }

        protected override async Task Handle(InitializeCompetitionCurrentSeasonCommand request, CancellationToken cancellationToken)
        {
            var competition = await competitionsRepository.GetCompetitionByCode(request.CompetitionCode);
            if (competition == null)
                throw new DomainException(Domain.Enums.ExceptionCode.ActiveCompetitionNotFound, $"CompetitionCode: {request.CompetitionCode}");
            var info = await competitionsProvider.GetCompetitionTeamsList(request.CompetitionCode);

            if (competition.LastProviderUpdate == info.Competition.LastUpdated) return;

            competition
                .SetActiveState(true)
                .SetLastProviderUpdate(info.Competition.LastUpdated);

            var season = competition.GetCurrentSeason();
            if (season == null)
                season = CreateSeason(info.Season, competition);
            else
                season = UpdateSeason(season, info);

            foreach (var teamInfo in info.Teams)
            {
                await AddTeam(teamInfo, season);
            }
            CheckWinner(season, info);

            await competitionsRepository.SaveCompetition(competition);

            await mediator.Send(new UpdateAllSeasonMatchesCommand { CompetitionCode = request.CompetitionCode });
            await mediator.Publish(new CompetitionInitializedEvent { CompetitionType = competition.Type });
        }

        private Season UpdateSeason(Season season, CompetitionTeamsListDto info)
        {
            if (season.ExternalId != info.Season.Id)
            {
                season.Deactivate();
                season = CreateSeason(info.Season, season.Competition);
            }
            else
                season.SetMatchday(info.Season.CurrentMatchday);

            return season;
        }

        private void CheckWinner(Season season, CompetitionTeamsListDto teamsInfo)
        {
            if (teamsInfo.Season.SeasonWinnerId.HasValue)
            {
                var winner = season.Teams.First(x => x.Team.ExternalId == teamsInfo.Season.SeasonWinnerId);
                season.SetWinner(winner.Team);
            }
        }

        private async Task AddTeam(TeamDto teamInfo, Season season)
        {
            if (season.Teams.Any(x => x.Team.ExternalId == teamInfo.Id)) return;

            if (await teamsRepository.TeamExistsForExternalId(teamInfo.Id))
                season.AddTeam(await teamsRepository.GetTeamByExternalId(teamInfo.Id));
            else
                season.AddTeam(new Team(teamInfo.Id, teamInfo.Name, teamInfo.ShortName, teamInfo.Tla, teamInfo.CrestUrl, teamInfo.Website));
        }

        private Season CreateSeason(CompetitionSeasonDto seasonInfo, Competition competition)
        {
            return new Season(competition, seasonInfo.Id, seasonInfo.StartDate, seasonInfo.EndDate, seasonInfo.CurrentMatchday)
                .SetActive();
        }
    }
}
