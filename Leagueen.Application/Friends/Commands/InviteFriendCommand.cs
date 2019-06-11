using MediatR;
using System;

namespace Leagueen.Application.Friends.Commands
{
    public class InviteFriendCommand : IRequest
    {
        public string Guid { get; set; }
        public int UserId { get; set; }
        public string AddresseeGuid { get; set; }
    }
}
