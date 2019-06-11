using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Friends.Commands.AcceptFriendInvite
{
    public class AcceptFriendInviteCommandHandler : AsyncRequestHandler<AcceptFriendInviteCommand>
    {
        protected override async Task Handle(AcceptFriendInviteCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
