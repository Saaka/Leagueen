using Leagueen.Application.Groups.Queries.Models;
using Leagueen.Application.Groups.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Groups.Queries.GetUserGroups
{
    public class GetUserGroupsQueryHandler : IRequestHandler<GetUserGroupsQuery, GetUserGroupsResult>
    {
        private readonly IUserGroupsRepository userGroupsRepository;

        public GetUserGroupsQueryHandler(
            IUserGroupsRepository userGroupsRepository)
        {
            this.userGroupsRepository = userGroupsRepository;
        }

        public async Task<GetUserGroupsResult> Handle(GetUserGroupsQuery request, CancellationToken cancellationToken)
        {
            var groups = await userGroupsRepository.GetUserGroups(request.UserId);

            return new GetUserGroupsResult
            {
                UserGroups = groups
            };
        }
    }
}
