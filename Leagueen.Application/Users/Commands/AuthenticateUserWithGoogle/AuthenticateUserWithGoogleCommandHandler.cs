using Leagueen.Application.Exceptions;
using Leagueen.Application.Security.Google;
using Leagueen.Application.Users.Models;
using Leagueen.Application.Users.Repositories;
using Leagueen.Common;
using Leagueen.Domain.Exceptions;
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
        private readonly IGoogleConfiguration googleConfiguration;

        public AuthenticateUserWithGoogleCommandHandler(
            IGuid guid,
            IUsersRepository usersRepository,
            IGoogleApiClient googleApiClient,
            IGoogleConfiguration googleConfiguration)
        {
            this.guid = guid;
            this.usersRepository = usersRepository;
            this.googleApiClient = googleApiClient;
            this.googleConfiguration = googleConfiguration;
        }

        public async Task<AuthUserCommandResult> Handle(AuthenticateUserWithGoogleCommand request, CancellationToken cancellationToken)
        {
            var moniker = guid.GetNormalizedGuid();
            var tokenInfo = await googleApiClient.GetTokenInfoAsync(request.GoogleToken);
            if (tokenInfo.ClientId != googleConfiguration.ClientId)
                throw new DomainException(Domain.Enums.ExceptionCode.InvalidGoogleToken);

            return new AuthUserCommandResult
            {
                User = new UserDto
                {
                    Moniker = moniker,
                    Email = tokenInfo.Email,
                    ImageUrl = tokenInfo.ImageUrl,
                    DisplayName = tokenInfo.DisplayName,
                    Token = null
                }
            };
        }
    }
}
