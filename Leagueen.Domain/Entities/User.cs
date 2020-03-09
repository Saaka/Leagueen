namespace Leagueen.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserGuid { get; set; }
        public string Email { get; set; }
        public string Moniker { get; set; }
        public string DisplayName { get; set; }
        public string ImageUrl { get; set; }
    }
}
