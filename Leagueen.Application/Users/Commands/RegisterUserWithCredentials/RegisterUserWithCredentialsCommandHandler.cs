using Leagueen.Application.Infrastructure;
using Leagueen.Application.Security;
using Leagueen.Application.Users.Models;
using Leagueen.Application.Users.Repositories;
using Leagueen.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Users.Commands.RegisterUserWithCredentials
{
    public class RegisterUserWithCredentialsCommandHandler : IRequestHandler<RegisterUserWithCredentialsCommand, Models.AuthUserCommandResult>
    {
        private readonly IGuid guid;
        private readonly IUsersRepository usersRepository;
        private readonly IJwtTokenFactory jwtTokenFactory;
        private readonly IProfileImageUrlProvider profileImageUrlProvider;

        public RegisterUserWithCredentialsCommandHandler(
            IGuid guid,
            IUsersRepository usersRepository,
            IJwtTokenFactory jwtTokenFactory,
            IProfileImageUrlProvider profileImageUrlProvider)
        {
            this.guid = guid;
            this.usersRepository = usersRepository;
            this.jwtTokenFactory = jwtTokenFactory;
            this.profileImageUrlProvider = profileImageUrlProvider;
        }

        public async Task<AuthUserCommandResult> Handle(RegisterUserWithCredentialsCommand request, CancellationToken cancellationToken)
        {
            var moniker = guid.GetNormalizedGuid();
            var imageUrl = profileImageUrlProvider.GetImageUrl(request.Email);
            var user = await usersRepository.CreateAsync(new CreateUserDto
            {
                DisplayName = request.DisplayName,
                Email = request.Email,
                Moniker = moniker,
                Password = request.Password,
                ImageUrl = imageUrl
            });

            var token = jwtTokenFactory.Create(user);

            return new AuthUserCommandResult
            {
                User = user,
                Token = token
            };
        }
    }
}
