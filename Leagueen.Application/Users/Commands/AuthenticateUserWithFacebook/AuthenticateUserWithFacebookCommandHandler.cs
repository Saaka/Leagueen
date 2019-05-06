using Leagueen.Application.Security;
using Leagueen.Application.Security.Google;
using Leagueen.Application.Users.Models;
using Leagueen.Application.Users.Repositories;
using Leagueen.Common;
using Leagueen.Domain.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Users.Commands.AuthenticateUserWithFacebook
{
    public class AuthenticateUserWithFacebookCommandHandler : IRequestHandler<AuthenticateUserWithFacebookCommand, AuthUserCommandResult>
    {
        private readonly IGuid guid;
        private readonly IFacebookApiClient facebookApiClient;
        private readonly IFacebookConfiguration facebookConfiguration;
        private readonly IUsersRepository usersRepository;
        private readonly IJwtTokenFactory jwtTokenFactory;

        public AuthenticateUserWithFacebookCommandHandler(
            IGuid guid,
            IFacebookApiClient facebookApiClient,
            IFacebookConfiguration facebookConfiguration,
            IUsersRepository usersRepository,
            IJwtTokenFactory jwtTokenFactory)
        {
            this.guid = guid;
            this.facebookApiClient = facebookApiClient;
            this.facebookConfiguration = facebookConfiguration;
            this.usersRepository = usersRepository;
            this.jwtTokenFactory = jwtTokenFactory;
        }

        public async Task<AuthUserCommandResult> Handle(AuthenticateUserWithFacebookCommand request, CancellationToken cancellationToken)
        {
            var tokenInfo = await facebookApiClient.GetTokenInfoAsync(request.FacebookToken);
            if (tokenInfo.ClientId != facebookConfiguration.FacebookAppId)
                throw new DomainException(Domain.Enums.ExceptionCode.InvalidFacebookToken);

            if (await usersRepository.FacebookUserExists(tokenInfo.Email, tokenInfo.ExternalUserId))
                return await UpdateExistingFacebookUser(tokenInfo);
            else
            {
                if (await usersRepository.IsEmailRegistered(tokenInfo.Email))
                    return await AddFacebookToExistingUser(tokenInfo);
                else
                    return await CreateNewFacebookUser(tokenInfo);
            }
        }

        private async Task<AuthUserCommandResult> UpdateExistingFacebookUser(TokenInfo tokenInfo)
        {
            var result = await usersRepository
                .UpdateExistingFacebookUser(tokenInfo.Email, tokenInfo.ImageUrl);

            var token = jwtTokenFactory.Create(result);
            return new AuthUserCommandResult
            {
                User = result,
                Token = token
            };
        }

        private async Task<AuthUserCommandResult> CreateNewFacebookUser(TokenInfo tokenInfo)
        {
            var moniker = guid.GetNormalizedGuid();
            var user = await usersRepository.CreateAsync(new CreateFacebookUserDto
            {
                DisplayName = tokenInfo.DisplayName,
                Email = tokenInfo.Email,
                FacebookId = tokenInfo.ExternalUserId,
                ImageUrl = tokenInfo.ImageUrl,
                Moniker = moniker
            });
            var token = jwtTokenFactory.Create(user);

            return new AuthUserCommandResult
            {
                User = user,
                Token = token
            };
        }

        private async Task<AuthUserCommandResult> AddFacebookToExistingUser(TokenInfo tokenInfo)
        {
            var result = await usersRepository
                .MergeUserWithFacebook(tokenInfo.Email, tokenInfo.ExternalUserId, tokenInfo.ImageUrl);

            var token = jwtTokenFactory.Create(result);
            return new AuthUserCommandResult
            {
                User = result,
                Token = token
            };
        }
    }
}
