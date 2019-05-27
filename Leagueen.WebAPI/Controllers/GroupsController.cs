using Leagueen.Application.Groups.Queries;
using Leagueen.Application.Groups.Queries.Models;
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
    }
}
