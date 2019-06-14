using Leagueen.Application.Competitions.Repositories;
using Leagueen.Application.DataProviders;
using Leagueen.Application.DataProviders.Competitions;
using Leagueen.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Competitions.Commands.UpdateCompetitionsSeasons
{
    public class UpdateCompetitionsSeasonsCommandHandler : AsyncRequestHandler<UpdateCompetitionsSeasonsCommand>
    {
        private readonly ICompetitionsProvider competitionsProvider;
        private readonly ICompetitionsRepository competitionsRepository;
        private readonly ICompetitionsAggregateRepository competitionsAggregateRepository;
        private readonly ITeamsRepository teamsRepository;

        public UpdateCompetitionsSeasonsCommandHandler(
            ICompetitionsProvider competitionsProvider,
            ICompetitionsRepository competitionsRepository,
            ICompetitionsAggregateRepository competitionsAggregateRepository,
            ITeamsRepository teamsRepository)
        {
            this.competitionsProvider = competitionsProvider;
            this.competitionsRepository = competitionsRepository;
            this.competitionsAggregateRepository = competitionsAggregateRepository;
            this.teamsRepository = teamsRepository;
        }

        protected override async Task Handle(UpdateCompetitionsSeasonsCommand request, CancellationToken cancellationToken)
        {
            var activeCompetitionsList = await competitionsRepository.GetAllActiveCompetitions(request.ProviderType);
            var competitionsInfo = await competitionsProvider.GetCompetitionsList();
            var toUpdate = new List<Competition>();

            foreach (var info in competitionsInfo.Competitions)
            {
                var competitionUpdateData = activeCompetitionsList.FirstOrDefault(x => x.Code == info.Code);

                if (competitionUpdateData == null || competitionUpdateData.LastProviderUpdate == info.LastUpdated)
                    continue;

                var competition = await competitionsAggregateRepository.GetCompetitionByCode(competitionUpdateData.Code);
                if (await UpdateCompetition(competition, info))
                    toUpdate.Add(competition);
            }

            if (toUpdate.Any())
                await competitionsAggregateRepository.SaveCompetitions(toUpdate);
        }

        private async Task<bool> UpdateCompetition(Competition competition, CompetitionDto info)
        {
            var currentSeason = competition.GetCurrentSeason();
            var seasonInfo = info.CurrentSeason;

            if (currentSeason == null)
                return false;

            if (currentSeason.ExternalId != info.CurrentSeason.Id)
            {
                currentSeason.Deactivate();
                var season = CreateNewSeason(competition, seasonInfo);
                competition.AddSeason(season);
            }
            else
            {
                currentSeason
                    .SetMatchday(seasonInfo.CurrentMatchday);
                await CheckWinner(currentSeason, info.CurrentSeason);
            }
            competition
                .SetLastProviderUpdate(info.LastUpdated);

            return true;
        }

        private async Task CheckWinner(Season season, CompetitionSeasonDto seasonInfo)
        {
            if (seasonInfo.SeasonWinnerId.HasValue)
            {
                var winner = await teamsRepository.GetTeamByExternalId(seasonInfo.SeasonWinnerId.Value.ToString(), season.Competition.DataProvider.Type);
                season.SetWinner(winner);
            }
        }

        private Season CreateNewSeason(Competition competition, CompetitionSeasonDto seasonInfo)
        {
            return new Season(competition, seasonInfo.Id, seasonInfo.StartDate, seasonInfo.EndDate, seasonInfo.CurrentMatchday)
                .SetActive();
        }
    }
}
