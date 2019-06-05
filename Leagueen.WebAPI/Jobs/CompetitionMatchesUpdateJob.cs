using Hangfire;
using Leagueen.Application.Competitions.Commands;
using Leagueen.Domain.Enums;
using MediatR;
using System.Threading.Tasks;

namespace Leagueen.WebAPI.Jobs
{
    public class CompetitionMatchesUpdateJob
    {
        private readonly IMediator mediator;

        public CompetitionMatchesUpdateJob(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [AutomaticRetry(Attempts = 0)]
        public async Task Run(DataProviderType providerType)
        {
            await mediator.Send(new UpdateCompetitionMatchesCommand { ProviderType = providerType });
        }
    }
}
