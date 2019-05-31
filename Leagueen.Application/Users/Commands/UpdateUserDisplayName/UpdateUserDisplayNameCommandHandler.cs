using Leagueen.Application.Users.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Users.Commands.UpdateUserDisplayName
{
    public class UpdateUserDisplayNameCommandHandler : AsyncRequestHandler<UpdateUserDisplayNameCommand>
    {
        private readonly IUsersRepository usersRepository;

        public UpdateUserDisplayNameCommandHandler(
            IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        protected override async Task Handle(UpdateUserDisplayNameCommand request, CancellationToken cancellationToken)
        {
            await usersRepository.UpdateUserDisplayName(request.UserId, request.DisplayName);
        }
    }
}
