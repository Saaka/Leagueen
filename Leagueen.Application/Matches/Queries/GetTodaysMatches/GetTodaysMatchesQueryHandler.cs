using Leagueen.Application.Matches.Queries.Models;
using Leagueen.Application.Matches.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Matches.Queries.GetTodaysMatches
{
    public class GetTodaysMatchesQueryHandler : IRequestHandler<GetTodaysMatchesQuery, GetTodaysMatchesQueryResult>
    {
        private readonly IMatchQueries matchQueries;

        public GetTodaysMatchesQueryHandler(IMatchQueries matchQueries)
        {
            this.matchQueries = matchQueries;
        }

        public async Task<GetTodaysMatchesQueryResult> Handle(GetTodaysMatchesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
