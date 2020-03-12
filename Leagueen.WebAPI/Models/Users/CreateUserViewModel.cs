namespace Leagueen.WebAPI.Models.Users
{
    public class CreateUserViewModel
    {
        public string UserGuid { get; private set; }
        public string Email { get; private set; }
        public string DisplayName { get; private set; }
        public string ImageUrl { get; private set; }
    }
}
