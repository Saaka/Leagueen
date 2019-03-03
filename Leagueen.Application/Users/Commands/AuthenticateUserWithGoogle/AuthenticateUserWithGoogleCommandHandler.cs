using Leagueen.Application.Users.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Users.Commands.AuthenticateUserWithGoogle
{
    public class AuthenticateUserWithGoogleCommandHandler : IRequestHandler<AuthenticateUserWithGoogleCommand, AuthUserCommandResult>
    {
        public Task<AuthUserCommandResult> Handle(AuthenticateUserWithGoogleCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
