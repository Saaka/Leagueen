using Leagueen.Application.Users.Commands;
using Leagueen.Application.Users.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Leagueen.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserWithCredentialsCommand request)
        {
            var result = await Mediator.Send(request);

            return GetRequestResult(result);
        }

        [HttpPost("google")]
        public async Task<IActionResult> Google([FromBody] AuthenticateUserWithGoogleCommand request)
        {
            var result = await Mediator.Send(request);

            return GetRequestResult(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthenticateUserWithCredentialsCommand request)
        {
            var result = await Mediator.Send(request);

            return GetRequestResult(result);
        }

        [Authorize]
        [HttpGet("user")]
        public async Task<IActionResult> GetUser()
        {
            var result = await Mediator.Send(new GetUserByIdQuery
            {
            });

            return GetRequestResult(result);
        }
    }
}
