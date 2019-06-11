using MediatR;

namespace Leagueen.Application.Friends.Commands
{
    public class AcceptFriendInviteCommand : IRequest
    {
        public string RequestGuid { get; set; }
        public int UserId { get; set; }
    }
}
