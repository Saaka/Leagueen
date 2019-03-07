using Leagueen.Application.Requests;

namespace Leagueen.Application.Users.Models
{
    public class AuthUserCommandResult : RequestResultBase
    {
        public AuthUserCommandResult()
        {
        }

        public AuthUserCommandResult(string error) : base(error)
        {
        }

        public UserDto User { get; set; }
        public string Token { get; set; }
    }
}
