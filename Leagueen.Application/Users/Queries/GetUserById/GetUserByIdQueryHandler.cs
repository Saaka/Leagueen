using Leagueen.Application.Security;
using Leagueen.Application.Users.Models;
using Leagueen.Application.Users.Repositories;
using Leagueen.Domain.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, AuthUserCommandResult>
    {
        private readonly IUsersRepository usersRepository;
        private readonly IJwtTokenFactory jwtTokenFactory;

        public GetUserByIdQueryHandler(
            IUsersRepository usersRepository,
            IJwtTokenFactory jwtTokenFactory)
        {
            this.usersRepository = usersRepository;
            this.jwtTokenFactory = jwtTokenFactory;
        }

        public async Task<AuthUserCommandResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await usersRepository.GetUserById(request.UserId);
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
