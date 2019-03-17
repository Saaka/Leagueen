using Leagueen.Application.Matches.Commands;
using MediatR;
using System.Threading.Tasks;

namespace Leagueen.Application.Competitions.Jobs
{
    public class CompetitionMatchesUpdateJob
    {
        private readonly IMediator mediator;

        public CompetitionMatchesUpdateJob(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task Run(string competitionCode)
        {
            var command = new UpdateAllSeasonMatchesCommand { CompetitionCode = competitionCode };
            await mediator.Send(command);
        }
    }
}
