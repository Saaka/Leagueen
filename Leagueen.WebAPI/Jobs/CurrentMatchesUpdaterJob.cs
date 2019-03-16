using Leagueen.Application.Matches.Commands;
using Leagueen.Domain.Enums;
using MediatR;
using System.Threading.Tasks;

namespace Leagueen.WebAPI.Jobs
{
    public class CurrentMatchesUpdaterJob
    {
        private readonly IMediator mediator;

        public CurrentMatchesUpdaterJob(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task Run(DataProviderType providerType)
        {
            await mediator.Send(new UpdateCurrentMatchesCommand { ProviderType = providerType });
        }
    }
}
