using System;

namespace Leagueen.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Moniker { get; set; }
        public string DisplayName { get; set; }
        public string ImageUrl { get; set; }
        public string PasswordHash { get; set; }
        public string GoogleId { get; set; }
    }
}
