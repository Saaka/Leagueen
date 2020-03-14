using Leagueen.Application.Users.Commands;
using Leagueen.Application.Users.Queries;
using Leagueen.WebAPI.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Leagueen.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateUser(CreateUserViewModel request)
        {
            await Mediator.Send(new CreateUserCommand(
                userGuid: request.UserGuid,
                email: request.Email,
                displayName: request.DisplayName,
                imageUrl: request.ImageUrl
                ));

            return Ok();
        }

        [HttpGet("{userGuid}")]
        public async Task<IActionResult> GetUser(Guid userGuid)
        {
            var result = await Mediator.Send(new GetUserByGuidQuery(userGuid));

            return Ok(result);
        }
    }
}
