using System;

namespace Leagueen.WebAPI.Models.Users
{
    public class CreateUserViewModel
    {
        public Guid UserGuid { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string ImageUrl { get; set; }
    }
}
