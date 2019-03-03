using Leagueen.Application.Users.Models;
using Leagueen.Common;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Users.Commands
{
    public class CreateUserWithCredentialsCommandHandler : IRequestHandler<CreateUserWithCredentialsCommand, Models.CreateUserCommandResult>
    {
        private readonly IGuid guid;

        public CreateUserWithCredentialsCommandHandler(
            IGuid guid)
        {
            this.guid = guid;
        }

        public Task<CreateUserCommandResult> Handle(CreateUserWithCredentialsCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
