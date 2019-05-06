namespace Leagueen.Application.Users.Models
{
    public class CreateFacebookUserDto
    {
        public string Moniker { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string FacebookId { get; set; }
    }
}
