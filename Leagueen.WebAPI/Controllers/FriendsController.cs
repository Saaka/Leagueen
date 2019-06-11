using Leagueen.Application.Friends.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Leagueen.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class FriendsController : BaseController
    {
        [Authorize]
        [HttpPost("invite/{addresseeGuid}")]
        public async Task<IActionResult> Invite(string addresseeGuid)
        {
            var guid = GuidProvider.GetNormalizedGuid();
            var userId = await GetUserId();

            await Mediator.Send(new InviteFriendCommand
            {
                Guid = guid,
                UserId = userId,
                AddresseeGuid = addresseeGuid,
            });

            return Ok(guid);
        }

        [Authorize]
        [HttpPost("accept/{guid}")]
        public async Task<IActionResult> Accept(string guid)
        {
            var userId = await GetUserId();

            await Mediator.Send(new AcceptFriendInviteCommand
            {
                RequestGuid = guid,
                UserId = userId
            });

            return Ok();
        }

        [Authorize]
        [HttpPost("reject/{guid}")]
        public async Task<IActionResult> Reject(string guid)
        {
            var userId = await GetUserId();

            await Mediator.Send(new RejectFriendInviteCommand
            {
                RequestGuid = guid,
                UserId = userId
            });

            return Ok();
        }
    }
}