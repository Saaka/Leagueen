using Leagueen.Application.DataProviders;
using Leagueen.Application.Matches.Repositories;
using Leagueen.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Matches.Commands.UpdateCurrentMatches
{
    public class UpdateCurrentMatchesCommandHandler : AsyncRequestHandler<UpdateCurrentMatchesCommand>
    {
        private readonly IDateTime dateTime;
        private readonly IMatchesRepository matchesRepository;
        private readonly IMatchesProvider matchesProvider;

        public UpdateCurrentMatchesCommandHandler(
            IDateTime dateTime,
            IMatchesRepository matchesRepository,
            IMatchesProvider matchesProvider)
        {
            this.dateTime = dateTime;
            this.matchesRepository = matchesRepository;
            this.matchesProvider = matchesProvider;
        }

        protected override async Task Handle(UpdateCurrentMatchesCommand request, CancellationToken cancellationToken)
        {
            var date = dateTime.GetUtcNow().Date;
            var matches = await matchesRepository.GetAllMatchesByDate(date);


            var matchesInfo = await matchesProvider.GetTodaysMatches();
        }
    }
}
