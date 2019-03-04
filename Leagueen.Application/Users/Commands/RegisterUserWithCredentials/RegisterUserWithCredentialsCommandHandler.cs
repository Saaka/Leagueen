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

        public RegisterUserWithCredentialsCommandHandler(
            IGuid guid,
            IUsersRepository usersRepository)
        {
            this.guid = guid;
            this.usersRepository = usersRepository;
        }

        public async Task<AuthUserCommandResult> Handle(RegisterUserWithCredentialsCommand request, CancellationToken cancellationToken)
        {
            var moniker = guid.GetNormalizedGuid();
            await usersRepository.CreateAsync(new CreateUserDto
            {
                DisplayName = request.DisplayName,
                Email = request.Email,
                Moniker = moniker,
                Password = request.Password
            });

            return new AuthUserCommandResult
            {
                User = new UserDto { Moniker = moniker }
            };
        }
    }
}
