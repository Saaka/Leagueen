using Hangfire;
using Leagueen.Application.Competitions.Commands;
using Leagueen.Domain.Enums;
using MediatR;
using System.Threading.Tasks;

namespace Leagueen.WebAPI.Jobs
{
    public class CompetitionsUpdateJob
    {
        private readonly IMediator mediator;

        public CompetitionsUpdateJob(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [AutomaticRetry(Attempts = 0)]
        public async Task Run(DataProviderType providerType)
        {
            await mediator.Send(new UpdateCompetitionsCommand { ProviderType = providerType });
        }
    }
}
