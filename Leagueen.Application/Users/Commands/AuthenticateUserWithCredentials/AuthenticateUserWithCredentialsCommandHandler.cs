using Leagueen.Application.Users.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Users.Commands.AuthenticateUserWithCredentials
{
    public class AuthenticateUserWithCredentialsCommandHandler : IRequestHandler<AuthenticateUserWithCredentialsCommand, AuthUserCommandResult>
    {
        public Task<AuthUserCommandResult> Handle(AuthenticateUserWithCredentialsCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
