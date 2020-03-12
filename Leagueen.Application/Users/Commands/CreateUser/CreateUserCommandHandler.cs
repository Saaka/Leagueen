using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : AsyncRequestHandler<CreateUserCommand>
    {
        protected override async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
