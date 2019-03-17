using Leagueen.Application.Matches.Queries.Models;
using Leagueen.Application.Matches.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Matches.Queries.GetTodaysMatches
{
    public class GetTodaysMatchesQueryHandler : IRequestHandler<GetTodaysMatchesQuery, GetTodaysMatchesQueryResult>
    {
        private readonly IGetTodaysMatchesQueryExecutor queryExecutor;

        public GetTodaysMatchesQueryHandler(IGetTodaysMatchesQueryExecutor matchQueries)
        {
            this.queryExecutor = matchQueries;
        }

        public async Task<GetTodaysMatchesQueryResult> Handle(GetTodaysMatchesQuery request, CancellationToken cancellationToken)
        {
            var competitions = await queryExecutor.Run();

            return new GetTodaysMatchesQueryResult
            {
                Competitions = competitions
            };
        }
    }
}
