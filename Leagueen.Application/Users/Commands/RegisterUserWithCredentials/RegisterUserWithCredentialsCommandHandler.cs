using Leagueen.Application.Users.Models;
using Leagueen.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Users.Commands.RegisterUserWithCredentials
{
    public class RegisterUserWithCredentialsCommandHandler : IRequestHandler<RegisterUserWithCredentialsCommand, Models.AuthUserCommandResult>
    {
        private readonly IGuid guid;

        public RegisterUserWithCredentialsCommandHandler(
            IGuid guid)
        {
            this.guid = guid;
        }

        public async Task<AuthUserCommandResult> Handle(RegisterUserWithCredentialsCommand request, CancellationToken cancellationToken)
        {

            return new AuthUserCommandResult("Not implemented");
        }
    }
}
