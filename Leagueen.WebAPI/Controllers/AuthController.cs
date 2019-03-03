using Leagueen.Application.Users.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Leagueen.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserWithCredentialsCommand request)
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
    }
}
