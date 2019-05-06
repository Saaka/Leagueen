using Leagueen.Application.Users.Models;
using MediatR;

namespace Leagueen.Application.Users.Commands
{
    public class AuthenticateUserWithFacebookCommand : IRequest<AuthUserCommandResult>
    {
        public string FacebookToken { get; set; }
    }
}
