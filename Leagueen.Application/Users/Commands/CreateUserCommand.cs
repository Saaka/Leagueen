using MediatR;

namespace Leagueen.Application.Users.Commands
{
    public class CreateUserCommand : IRequest
    {
        public CreateUserCommand(string userGuid, string email, string displayName, string imageUrl)
        {
            UserGuid = userGuid;
            Email = email;
            DisplayName = displayName;
            ImageUrl = imageUrl;
        }

        public string UserGuid { get; private set; }
        public string Email { get; private set; }
        public string DisplayName { get; private set; }
        public string ImageUrl { get; private set; }
    }
}
