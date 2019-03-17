using Leagueen.Application.Competitions.Jobs;
using Leagueen.Application.Infrastructure.Jobs;
using Leagueen.Application.Matches.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Competitions.Events.CompetitionInitialized
{
    public class CompetitionInitializedEventHandler : INotificationHandler<CompetitionInitializedEvent>
    {
        private readonly IJobsManager jobsManager;
        private readonly ICompetitionJobsConfiguration jobsConfiguration;

        public CompetitionInitializedEventHandler(
            IJobsManager jobsManager,
            ICompetitionJobsConfiguration jobsConfiguration)
        {
            this.jobsManager = jobsManager;
            this.jobsConfiguration = jobsConfiguration;
        }

        public async Task Handle(CompetitionInitializedEvent notification, CancellationToken cancellationToken)
        {
            var executionTime = await jobsConfiguration.GetExecutionTime(notification.CompetitionType);

            jobsManager.RegisterDailyTask<CompetitionMatchesUpdateJob>(
                $"{nameof(UpdateAllSeasonMatchesCommand)}_{notification.CompetitionType.ToString()}",
                j => j.Run(notification.CompetitionType.ToString()),
                executionTime);
        }
    }
}
