using Leagueen.Application.Competitions.ProviderModels;
using Leagueen.Application.Competitions.Repositories;
using Leagueen.Domain.Entities;
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
            var teamsInfo = await competitionsProvider.GetCompetitionTeamsList(request.CompetitionCode);
            var competition = await competitionsRepository.GetCompetitionByCode(request.CompetitionCode);
            var season = competition.GetCurrentSeason();
            if (season == null)
                season = CreateSeason(teamsInfo.Season, competition);

            foreach (var teamInfo in teamsInfo.Teams)
            {
                await AddTeam(teamInfo, season);
            }

            await seasonsRepository.SaveSeason(season);
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
            //TODO Set winner
            return new Season(competition, seasonInfo.Id, seasonInfo.StartDate, seasonInfo.EndDate, seasonInfo.CurrentMatchday)
                .SetActive();
        }
    }
}
