using Leagueen.Application.Requests;

namespace Leagueen.Application.Users.Models
{
    public class SigninUserCommandResult : RequestResultBase
    {
        public SigninUserCommandResult()
        {
        }

        public SigninUserCommandResult(string error) : base(error)
        {
        }

        public string Moniker { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string ImageUrl { get; set; }
    }
}
