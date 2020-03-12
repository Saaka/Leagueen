using Leagueen.Application.Users.Commands;
using Leagueen.WebAPI.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Leagueen.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> GetTodaysMatches(CreateUserViewModel model)
        {
            await Mediator.Send(new CreateUserCommand(
                userGuid: model.UserGuid,
                email: model.Email,
                displayName: model.DisplayName,
                imageUrl: model.ImageUrl
                ));

            return Ok();
        }
    }
}
