using Leagueen.Application.Users.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Users.Commands.AuthenticateUserWithFacebook
{
    public class AuthenticateUserWithFacebookCommandHandler : IRequestHandler<AuthenticateUserWithFacebookCommand, AuthUserCommandResult>
    {
        public async Task<AuthUserCommandResult> Handle(AuthenticateUserWithFacebookCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
