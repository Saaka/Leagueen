using Leagueen.Application.Matches.Queries.Models;
using Leagueen.Application.Matches.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Matches.Queries.GetMatchesByDate
{
    public class GetMatchesByDateQueryHandler : IRequestHandler<GetMatchesByDateQuery, GetMatchesQueryResult>
    {
        private readonly IGetMatchesByDateQueryExecutor queryExecutor;

        public GetMatchesByDateQueryHandler(
            IGetMatchesByDateQueryExecutor matchQueries)
        {
            this.queryExecutor = matchQueries;
        }

        public async Task<GetMatchesQueryResult> Handle(GetMatchesByDateQuery request, CancellationToken cancellationToken)
        {
            var competitions = await queryExecutor.Run(request.Date);
            
            return new GetMatchesQueryResult
            {
                Competitions = competitions
            };
        }
    }
}
