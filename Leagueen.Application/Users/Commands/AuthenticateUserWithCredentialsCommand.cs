using Leagueen.Application.Users.Models;
using MediatR;

namespace Leagueen.Application.Users.Commands
{
    public class AuthenticateUserWithCredentialsCommand : IRequest<AuthUserCommandResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
