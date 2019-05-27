using Leagueen.Application.Groups.Queries.Models;
using MediatR;

namespace Leagueen.Application.Groups.Queries
{
    public class GetUserGroupsQuery : IRequest<GetUserGroupsResult>
    {
        public int UserId { get; set; }
    }
}
