using Leagueen.Application.Security.Google;
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
        private readonly IGoogleApiClient googleApiClient;

        public AuthenticateUserWithGoogleCommandHandler(
            IGuid guid,
            IUsersRepository usersRepository,
            IGoogleApiClient googleApiClient)
        {
            this.guid = guid;
            this.usersRepository = usersRepository;
            this.googleApiClient = googleApiClient;
        }

        public async Task<AuthUserCommandResult> Handle(AuthenticateUserWithGoogleCommand request, CancellationToken cancellationToken)
        {
            var moniker = guid.GetNormalizedGuid();
            var tokenInfo = await googleApiClient.GetTokenInfoAsync(request.GoogleToken);

            return new AuthUserCommandResult
            {
                User = new UserDto { Moniker = moniker, Email = tokenInfo.Email }
            };
        }
    }
}
