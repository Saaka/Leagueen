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

        public UpdateCompetitionsSeasonsCommandHandler(
            ICompetitionsProvider competitionsProvider,
            ICompetitionsRepository competitionsRepository)
        {
            this.competitionsProvider = competitionsProvider;
            this.competitionsRepository = competitionsRepository;
        }

        protected override async Task Handle(UpdateCompetitionsSeasonsCommand request, CancellationToken cancellationToken)
        {
            var competitions = await competitionsRepository.GetAllActiveCompetitions();
            var competitionsInfo = await competitionsProvider.GetCompetitionsList();
            var toUpdate = new List<Competition>();

            foreach (var info in competitionsInfo.Competitions)
            {
                var competition = competitions.FirstOrDefault(x => x.Code == info.Code);

                if (competition == null || competition.LastProviderUpdate == info.LastUpdated)
                    continue;

                if (UpdateCompetition(competition, info))
                    toUpdate.Add(competition);
            }

            if (toUpdate.Any())
                await competitionsRepository.SaveCompetitions(toUpdate);
        }

        private bool UpdateCompetition(Competition competition, CompetitionDto info)
        {
            var currentSeason = competition.GetCurrentSeason();
            var seasonInfo = info.CurrentSeason;

            if (currentSeason == null)
                return false;

            if (currentSeason.ExternalId != info.CurrentSeason.Id)
            {
                currentSeason.Deactivate();
                currentSeason = CreateNewSeason(competition, seasonInfo);
            }
            else
            {
                currentSeason
                    .SetMatchday(seasonInfo.CurrentMatchday);
            }
            competition
                .SetLastProviderUpdate(info.LastUpdated);

            return true;
        }

        private Season CreateNewSeason(Competition competition, CompetitionSeasonDto seasonInfo)
        {
            var newSeason = new Season(competition, seasonInfo.Id, seasonInfo.StartDate, seasonInfo.EndDate, seasonInfo.CurrentMatchday)
                .SetActive();

            return newSeason;
        }
    }
}
