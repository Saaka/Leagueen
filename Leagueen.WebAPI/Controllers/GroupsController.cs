using Leagueen.Application.Groups.Commands;
using Leagueen.Application.Groups.Queries;
using Leagueen.Application.Groups.Queries.Models;
using Leagueen.Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Leagueen.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class GroupsController : BaseController
    {
        [Authorize]
        [HttpGet("userGroups")]
        public async Task<GetUserGroupsResult> List()
        {
            var userId = await GetUserId();
            return await Mediator.Send(new GetUserGroupsQuery { UserId = userId });
        }

        [Authorize]
        [HttpPost]
        public async Task<GuidResult> Create(CreateGroupCommand request)
        {
            var userId = await GetUserId();
            var guid = GuidProvider.GetNormalizedGuid();

            request.GroupGuid = guid;
            request.OwnerId = userId;

            await Mediator.Send(request);

            return new GuidResult(guid);
        }
    }
}
