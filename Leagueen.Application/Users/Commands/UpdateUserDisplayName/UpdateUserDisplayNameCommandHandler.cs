using Leagueen.Application.Requests;
using Leagueen.Application.Users.Repositories;
using Leagueen.Domain.Enums;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Users.Commands.UpdateUserDisplayName
{
    public class UpdateUserDisplayNameCommandHandler : IRequestHandler<UpdateUserDisplayNameCommand, RequestResultBase>
    {
        private readonly IUsersRepository usersRepository;

        public UpdateUserDisplayNameCommandHandler(
            IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }
        public async Task<RequestResultBase> Handle(UpdateUserDisplayNameCommand request, CancellationToken cancellationToken)
        {
            await usersRepository.UpdateUserDisplayName(request.UserId, request.DisplayName);

            return new RequestResultBase();
        }
    }
}
