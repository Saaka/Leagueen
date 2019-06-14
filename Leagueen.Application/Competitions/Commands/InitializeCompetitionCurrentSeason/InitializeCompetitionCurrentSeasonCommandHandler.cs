using Leagueen.Application.Competitions.Events;
using Leagueen.Application.Competitions.Repositories;
using Leagueen.Application.DataProviders;
using Leagueen.Application.DataProviders.Competitions;
using Leagueen.Application.Matches.Commands;
using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
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
        private readonly ICompetitionsAggregateRepository competitionsAggregateRepository;
        private readonly ICompetitionsRepository competitionsRepository;
        private readonly ITeamsRepository teamsRepository;
        private readonly IMediator mediator;

        public InitializeCompetitionCurrentSeasonCommandHandler(
            ICompetitionsProvider competitionsProvider,
            ISeasonsRepository seasonsRepository,
            ICompetitionsAggregateRepository competitionsAggregateRepository,
            ICompetitionsRepository competitionsRepository,
            ITeamsRepository teamsRepository,
            IMediator mediator)
        {
            this.competitionsProvider = competitionsProvider;
            this.seasonsRepository = seasonsRepository;
            this.competitionsAggregateRepository = competitionsAggregateRepository;
            this.competitionsRepository = competitionsRepository;
            this.teamsRepository = teamsRepository;
            this.mediator = mediator;
        }

        protected override async Task Handle(InitializeCompetitionCurrentSeasonCommand request, CancellationToken cancellationToken)
        {
            var competition = await competitionsAggregateRepository.GetCompetitionByCode(request.CompetitionCode);
            if (competition == null)
                throw new DomainException(ExceptionCode.ActiveCompetitionNotFound, $"CompetitionCode: {request.CompetitionCode}");
            var info = await competitionsProvider.GetCompetitionTeamsList(request.CompetitionCode);
            
            competition
                .SetActiveState(true)
                .SetLastProviderUpdate(info.Competition.LastUpdated);

            var season = competition.GetCurrentSeason();
            if (season == null)
            {
                season = CreateSeason(info.Season, competition);
                competition.AddSeason(season);
            }
            else
                season = UpdateSeason(season, info);

            foreach (var teamInfo in info.Teams)
            {
                await AddTeam(teamInfo, season, competition.DataProvider.Type);
            }
            CheckWinner(season, info);

            await competitionsAggregateRepository.SaveCompetition(competition);

            if (request.InitializeMatches)
                await mediator.Send(new UpdateAllSeasonMatchesCommand { CompetitionType = competition.Type });

            await mediator.Publish(new CompetitionInitializedEvent { CompetitionType = competition.Type });
        }

        private Season UpdateSeason(Season season, CompetitionTeamsListDto info)
        {
            if (season.ExternalId != info.Season.Id)
            {
                season.Deactivate();
                season = CreateSeason(info.Season, season.Competition);
                season.Competition.AddSeason(season);
            }
            else
                season.SetMatchday(info.Season.CurrentMatchday);

            return season;
        }

        private void CheckWinner(Season season, CompetitionTeamsListDto teamsInfo)
        {
            if (teamsInfo.Season.SeasonWinnerId.HasValue)
            {
                var winner = season.Teams
                    .First(x => x.Team.ExternalMappings
                                        .Any(m => m.ExternalId == teamsInfo.Season.SeasonWinnerId.ToString() && m.ProviderType == season.Competition.DataProvider.Type));

                season.SetWinner(winner.Team);
            }
        }

        private async Task AddTeam(TeamDto teamInfo, Season season, DataProviderType providerType)
        {
            if (season.Teams.Any(x => x.Team.ExternalMappings.Any(m => m.ExternalId == teamInfo.Id.ToString() && m.ProviderType == providerType))) return;

            if (await teamsRepository.TeamExistsForExternalId(teamInfo.Id.ToString(), providerType))
                season.AddTeam(await teamsRepository.GetTeamByExternalId(teamInfo.Id.ToString(), providerType));
            else
            {
                var team = new Team(teamInfo.Name, teamInfo.ShortName, teamInfo.Tla, teamInfo.CrestUrl, teamInfo.Website)
                    .AddExternalMapping(teamInfo.Id.ToString(), providerType);

                season.AddTeam(team);
            }
        }

        private Season CreateSeason(CompetitionSeasonDto seasonInfo, Competition competition)
        {
            return new Season(competition, seasonInfo.Id, seasonInfo.StartDate, seasonInfo.EndDate, seasonInfo.CurrentMatchday)
                .SetActive();
        }
    }
}
