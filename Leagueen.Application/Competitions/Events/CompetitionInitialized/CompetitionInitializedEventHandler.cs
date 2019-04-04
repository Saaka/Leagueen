using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Competitions.Events.CompetitionInitialized
{
    public class CompetitionInitializedEventHandler : INotificationHandler<CompetitionInitializedEvent>
    {
        private readonly ILogger logger;

        public CompetitionInitializedEventHandler(
            ILogger<CompetitionInitializedEventHandler> logger)
        {
            this.logger = logger;
        }

        public async Task Handle(CompetitionInitializedEvent notification, CancellationToken cancellationToken)
        {
            //Event triggered after competition is initialized. Can be used for worker initialization etc.
            logger.LogInformation($"Competition {notification.CompetitionType.ToString()} initialized");
        }
    }
}
