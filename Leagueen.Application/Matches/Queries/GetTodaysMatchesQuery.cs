using Leagueen.Application.Matches.Queries.Models;
using MediatR;

namespace Leagueen.Application.Matches.Queries
{
    public class GetTodaysMatchesQuery : IRequest<GetTodaysMatchesQueryResult>
    { }
}
