using Leagueen.Application.Users.Models;
using MediatR;

namespace Leagueen.Application.Users.Queries
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public int UserId { get; set; }
    }
}
