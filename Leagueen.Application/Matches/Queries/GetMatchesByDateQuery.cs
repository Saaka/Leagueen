using Leagueen.Application.Matches.Queries.Models;
using MediatR;
using System;

namespace Leagueen.Application.Matches.Queries
{
    public class GetMatchesByDateQuery : IRequest<GetMatchesQueryResult>
    {
        public DateTime Date { get; set; }
    }
}
