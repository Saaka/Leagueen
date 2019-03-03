using Leagueen.Application.Users.Models;
using MediatR;

namespace Leagueen.Application.Users.Queries
{
    public class GetUserByIdQuery : IRequest<AuthUserCommandResult>
    {
        public int UserId { get; set; }
    }
}
