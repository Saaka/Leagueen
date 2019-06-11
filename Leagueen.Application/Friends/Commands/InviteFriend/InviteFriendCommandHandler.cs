using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Leagueen.Application.Friends.Commands.InviteFriend
{
    public class InviteFriendCommandHanlder : AsyncRequestHandler<InviteFriendCommand>
    {
        protected override async Task Handle(InviteFriendCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
