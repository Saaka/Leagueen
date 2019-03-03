using Leagueen.Application.Users.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Leagueen.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, AuthUserCommandResult>
    {
        public Task<AuthUserCommandResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
