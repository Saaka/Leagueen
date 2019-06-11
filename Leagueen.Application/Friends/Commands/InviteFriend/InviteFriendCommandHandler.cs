using System.Threading;
using System.Threading.Tasks;
using Leagueen.Application.Friends.Repositories;
using Leagueen.Application.Users.Repositories;
using Leagueen.Common;
using Leagueen.Domain.Entities;
using Leagueen.Domain.Exceptions;
using MediatR;

namespace Leagueen.Application.Friends.Commands.InviteFriend
{
    public class InviteFriendCommandHanlder : AsyncRequestHandler<InviteFriendCommand>
    {
        private readonly IFriendshipAggregateRepository friendshipAggregateRepository;
        private readonly IFriendshipRequestsRepository friendshipRequestsRepository;
        private readonly IUsersRepository usersRepository;
        private readonly IDateTime dateTime;

        public InviteFriendCommandHanlder(
            IFriendshipAggregateRepository friendshipAggregateRepository,
            IFriendshipRequestsRepository friendshipRequestsRepository,
            IUsersRepository usersRepository,
            IDateTime dateTime)
        {
            this.friendshipAggregateRepository = friendshipAggregateRepository;
            this.friendshipRequestsRepository = friendshipRequestsRepository;
            this.usersRepository = usersRepository;
            this.dateTime = dateTime;
        }

        protected override async Task Handle(InviteFriendCommand command, CancellationToken cancellationToken)
        {
            var addresseeId = await usersRepository.GetUserIdByMoniker(command.AddresseeGuid);
            if (!addresseeId.HasValue)
                throw new DomainException(Domain.Enums.ExceptionCode.UserNotFound);

            var requestAlreadyExists = await friendshipRequestsRepository.FriendshipRequestExists(command.UserId, addresseeId.Value);
            if (requestAlreadyExists)
                throw new DomainException(Domain.Enums.ExceptionCode.FriendshipRequestIsPending);

            var request = new FriendshipRequest(command.Guid, command.UserId, addresseeId.Value, dateTime.GetUtcNow());
            await friendshipAggregateRepository.SaveFriendshipRequest(request);
        }
    }
}
