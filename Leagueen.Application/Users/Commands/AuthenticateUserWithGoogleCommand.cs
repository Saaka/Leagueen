using Leagueen.Application.Users.Models;
using MediatR;

namespace Leagueen.Application.Users.Commands
{
    public class AuthenticateUserWithGoogleCommand : IRequest<AuthUserCommandResult>
    {
        public string GoogleToken { get; set; }
    }
}
