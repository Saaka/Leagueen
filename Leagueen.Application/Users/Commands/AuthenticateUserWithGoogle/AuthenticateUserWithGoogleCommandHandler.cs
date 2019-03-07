using Leagueen.Application.Security;
using Leagueen.Application.Security.Google;
using Leagueen.Application.Users.Models;
using Leagueen.Application.Users.Repositories;
using Leagueen.Common;
using Leagueen.Domain.Exceptions;
using MediatR;
using System;
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
        private readonly IJwtTokenFactory jwtTokenFactory;

        public AuthenticateUserWithGoogleCommandHandler(
            IGuid guid,
            IUsersRepository usersRepository,
            IGoogleApiClient googleApiClient,
            IGoogleConfiguration googleConfiguration,
            IJwtTokenFactory jwtTokenFactory)
        {
            this.guid = guid;
            this.usersRepository = usersRepository;
            this.googleApiClient = googleApiClient;
            this.googleConfiguration = googleConfiguration;
            this.jwtTokenFactory = jwtTokenFactory;
        }

        public async Task<AuthUserCommandResult> Handle(AuthenticateUserWithGoogleCommand request, CancellationToken cancellationToken)
        {
            var tokenInfo = await googleApiClient.GetTokenInfoAsync(request.GoogleToken);
            if (tokenInfo.ClientId != googleConfiguration.ClientId)
                throw new DomainException(Domain.Enums.ExceptionCode.InvalidGoogleToken);

            if (await usersRepository.GoogleUserExists(tokenInfo.Email, tokenInfo.ExternalUserId))
                return await UpdateExistingGoogleUser(tokenInfo);
            else
            {
                if (await usersRepository.IsEmailRegistered(tokenInfo.Email))
                    return await AddGoogleToExistingUser(tokenInfo);
                else
                    return await CreateNewGoogleUser(tokenInfo);
            }
        }

        private async Task<AuthUserCommandResult> CreateNewGoogleUser(TokenInfo tokenInfo)
        {
            var moniker = guid.GetNormalizedGuid();
            await usersRepository.CreateAsync(new CreateGoogleUserDto
            {
                DisplayName = tokenInfo.DisplayName,
                Email = tokenInfo.Email,
                GoogleId = tokenInfo.ExternalUserId,
                ImageUrl = tokenInfo.ImageUrl,
                Moniker = moniker
            });
            var token = jwtTokenFactory.Create(tokenInfo.Email);

            return new AuthUserCommandResult
            {
                User = new UserDto
                {
                    DisplayName = tokenInfo.DisplayName,
                    Email = tokenInfo.Email,
                    ImageUrl = tokenInfo.ImageUrl,
                    Moniker = moniker,
                    Token = token
                }
            };
        }

        private async Task<AuthUserCommandResult> AddGoogleToExistingUser(TokenInfo tokenInfo)
        {
            var result = await usersRepository
                .MergeUserWithGoogle(tokenInfo.Email, tokenInfo.ExternalUserId, tokenInfo.ImageUrl);

            result.Token = jwtTokenFactory.Create(tokenInfo.Email);
            return new AuthUserCommandResult
            {
                User = result
            };
        }

        private async Task<AuthUserCommandResult> UpdateExistingGoogleUser(TokenInfo tokenInfo)
        {
            var result = await usersRepository
                .UpdateExistingGoogleUser(tokenInfo.Email, tokenInfo.ImageUrl);

            result.Token = jwtTokenFactory.Create(tokenInfo.Email);
            return new AuthUserCommandResult
            {
                User = result
            };
        }
    }
}
