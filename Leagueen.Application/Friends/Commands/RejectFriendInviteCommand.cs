using MediatR;

namespace Leagueen.Application.Friends.Commands
{
    public class RejectFriendInviteCommand : IRequest
    {
        public string RequestGuid { get; set; }
        public int UserId { get; set; }
    }
}
