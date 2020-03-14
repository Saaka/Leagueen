using MediatR;
using System;

namespace Leagueen.Application.Friends.Commands
{
    public class InviteFriendCommand : IRequest
    {
        public Guid Guid { get; set; }
        public int UserId { get; set; }
        public Guid AddresseeGuid { get; set; }
    }
}
