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
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUsersRepository usersRepository;

        public GetUserByIdQueryHandler(
            IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await usersRepository.GetUserById(request.UserId);
            if (user == null)
                throw new DomainException(Domain.Enums.ExceptionCode.UserNotFound);

            return user;
        }
    }
}
