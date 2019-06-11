using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Friends.Commands.RejectFriendInvite
{
    public class RejectFriendInviteCommandHandler : AsyncRequestHandler<RejectFriendInviteCommand>
    {
        protected override async Task Handle(RejectFriendInviteCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
