using Leagueen.Application.Competitions.Repositories;
using Leagueen.Application.Matches.Commands;
using Leagueen.Application.UpdateLogs.Repositories;
using Leagueen.Common;
using Leagueen.Domain.Enums;
using MediatR;
using System.Linq;
using System.Threading.Tasks;

namespace Leagueen.Application.Competitions.Jobs
{
    public class CompetitionMatchesUpdateJob
    {
        private readonly IMediator mediator;
        private readonly IUpdateLogsRepository updateLogsRepository;
        private readonly ICompetitionsRepository competitionsRepository;
        private readonly IDateTime dateTime;

        public CompetitionMatchesUpdateJob(
            IMediator mediator,
            IUpdateLogsRepository updateLogsRepository,
            ICompetitionsRepository competitionsRepository,
            IDateTime dateTime)
        {
            this.mediator = mediator;
            this.updateLogsRepository = updateLogsRepository;
            this.competitionsRepository = competitionsRepository;
            this.dateTime = dateTime;
        }

        public async Task Run(DataProviderType dataProviderType)
        {
            var updates = await updateLogsRepository.GetCompetitionUpdatesForProvider(dataProviderType, dateTime.GetUtcNow());
            var competitionTypes = await competitionsRepository.GetAllActiveCompetitionTypesForProvider(dataProviderType);
            foreach (var compType in competitionTypes)
            {
                if (updates.Any(x => x.CompetitionType.Value == compType)) continue;

                var command = new UpdateAllSeasonMatchesCommand { CompetitionCode = compType.ToString() };
                await mediator.Send(command);
            }
        }
    }
}
