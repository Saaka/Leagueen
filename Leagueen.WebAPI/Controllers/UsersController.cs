using Leagueen.Application.Users.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Leagueen.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        [Authorize]
        [HttpPost("updateDisplayName/{displayName}")]
        public async Task<IActionResult> UpdateAllSeasonMatches(string displayName)
        {
            var userId = await GetUserId();
            var result = await Mediator.Send(new UpdateUserDisplayNameCommand { DisplayName = displayName, UserId = userId });

            return GetRequestResult(result);
        }
    }
}
