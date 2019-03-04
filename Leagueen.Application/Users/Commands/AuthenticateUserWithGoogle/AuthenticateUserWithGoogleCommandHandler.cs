using Leagueen.Application.Users.Models;
using Leagueen.Application.Users.Repositories;
using Leagueen.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Users.Commands.AuthenticateUserWithGoogle
{
    public class AuthenticateUserWithGoogleCommandHandler : IRequestHandler<AuthenticateUserWithGoogleCommand, AuthUserCommandResult>
    {
        private readonly IGuid guid;
        private readonly IUsersRepository usersRepository;

        public AuthenticateUserWithGoogleCommandHandler(
            IGuid guid,
            IUsersRepository usersRepository)
        {
            this.guid = guid;
            this.usersRepository = usersRepository;
        }

        public async Task<AuthUserCommandResult> Handle(AuthenticateUserWithGoogleCommand request, CancellationToken cancellationToken)
        {
            var moniker = guid.GetNormalizedGuid();


            return new AuthUserCommandResult
            {
                User = new UserDto { Moniker = moniker }
            };
        }
    }
}
