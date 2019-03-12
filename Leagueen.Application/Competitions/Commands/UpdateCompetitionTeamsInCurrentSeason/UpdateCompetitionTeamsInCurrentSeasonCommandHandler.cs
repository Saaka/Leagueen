using Leagueen.Application.Competitions.ProviderModels;
using Leagueen.Application.Competitions.Repositories;
using Leagueen.Domain.Entities;
using Leagueen.Domain.Exceptions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Competitions.Commands.UpdateCompetitionTeamsInCurrentSeason
{
    public class UpdateCompetitionTeamsInCurrentSeasonCommandHandler : AsyncRequestHandler<UpdateCompetitionTeamsInCurrentSeasonCommand>
    {
        private readonly ICompetitionsProvider competitionsProvider;
        private readonly ISeasonsRepository seasonsRepository;
        private readonly ICompetitionsRepository competitionsRepository;
        private readonly ITeamsRepository teamsRepository;

        public UpdateCompetitionTeamsInCurrentSeasonCommandHandler(
            ICompetitionsProvider competitionsProvider,
            ISeasonsRepository seasonsRepository,
            ICompetitionsRepository competitionsRepository,
            ITeamsRepository teamsRepository)
        {
            this.competitionsProvider = competitionsProvider;
            this.seasonsRepository = seasonsRepository;
            this.competitionsRepository = competitionsRepository;
            this.teamsRepository = teamsRepository;
        }

        protected override async Task Handle(UpdateCompetitionTeamsInCurrentSeasonCommand request, CancellationToken cancellationToken)
        {
            var competition = await competitionsRepository.GetCompetitionByCode(request.CompetitionCode);
            if (competition == null)
                throw new DomainException(Domain.Enums.ExceptionCode.ActiveCompetitionNotFound, $"CompetitionCode: {request.CompetitionCode}");
            var teamsInfo = await competitionsProvider.GetCompetitionTeamsList(request.CompetitionCode);
            var season = competition.GetCurrentSeason();
            if (season == null)
                season = CreateSeason(teamsInfo.Season, competition);

            foreach (var teamInfo in teamsInfo.Teams)
            {
                await AddTeam(teamInfo, season);
            }
            CheckWinner(season, teamsInfo);

            await seasonsRepository.SaveSeason(season);
        }

        private void CheckWinner(Season season, CompetitionTeamsListDto teamsInfo)
        {
            if(teamsInfo.Season.Winner != null)
            {
                var winner = season.Teams.First(x => x.Team.ExternalId == teamsInfo.Season.Winner.Id);
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
