using Leagueen.Application.Matches.Queries.Models;
using Leagueen.Application.Matches.Repositories;
using Leagueen.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Matches.Queries.GetTodaysMatches
{
    public class GetTodaysMatchesQueryHandler : IRequestHandler<GetTodaysMatchesQuery, GetMatchesQueryResult>
    {
        private readonly IGetMatchesByDateQueryExecutor queryExecutor;
        private readonly IDateTime dateTime;

        public GetTodaysMatchesQueryHandler(
            IGetMatchesByDateQueryExecutor matchQueries,
            IDateTime dateTime)
        {
            this.queryExecutor = matchQueries;
            this.dateTime = dateTime;
        }

        public async Task<GetMatchesQueryResult> Handle(GetTodaysMatchesQuery request, CancellationToken cancellationToken)
        {
            var date = dateTime.GetUtcNow().Date;
            var competitions = await queryExecutor.Run(date);

            return new GetMatchesQueryResult
            {
                Competitions = competitions
            };
        }
    }
}
