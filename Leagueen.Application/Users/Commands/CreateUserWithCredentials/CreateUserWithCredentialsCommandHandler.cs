using Leagueen.Application.Users.Models;
using Leagueen.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Users.Commands.CreateUserWithCredentials
{
    public class CreateUserWithCredentialsCommandHandler : IRequestHandler<CreateUserWithCredentialsCommand, Models.SigninUserCommandResult>
    {
        private readonly IGuid guid;

        public CreateUserWithCredentialsCommandHandler(
            IGuid guid)
        {
            this.guid = guid;
        }

        public async Task<SigninUserCommandResult> Handle(CreateUserWithCredentialsCommand request, CancellationToken cancellationToken)
        {

            return new SigninUserCommandResult("Not implemented");
        }
    }
}
