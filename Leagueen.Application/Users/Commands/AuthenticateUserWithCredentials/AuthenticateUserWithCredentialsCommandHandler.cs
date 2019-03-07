using Leagueen.Application.Security;
using Leagueen.Application.Users.Models;
using Leagueen.Application.Users.Repositories;
using Leagueen.Domain.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Users.Commands.AuthenticateUserWithCredentials
{
    public class AuthenticateUserWithCredentialsCommandHandler : IRequestHandler<AuthenticateUserWithCredentialsCommand, AuthUserCommandResult>
    {
        private readonly IUsersRepository usersRepository;
        private readonly IJwtTokenFactory jwtTokenFactory;

        public AuthenticateUserWithCredentialsCommandHandler(
            IUsersRepository usersRepository,
            IJwtTokenFactory jwtTokenFactory)
        {
            this.usersRepository = usersRepository;
            this.jwtTokenFactory = jwtTokenFactory;
        }

        public async Task<AuthUserCommandResult> Handle(AuthenticateUserWithCredentialsCommand request, CancellationToken cancellationToken)
        {
            var user = await usersRepository.GetUserByCredentials(request.Email, request.Password);
            if (user == null)
                throw new DomainException(Domain.Enums.ExceptionCode.UserNotFound);

            user.Token = jwtTokenFactory.Create(user.Moniker);
            return new AuthUserCommandResult
            {
                User = user
            };
        }
    }
}
