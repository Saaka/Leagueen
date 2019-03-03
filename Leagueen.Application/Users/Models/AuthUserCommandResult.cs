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

        public string Moniker { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string ImageUrl { get; set; }
    }
}
