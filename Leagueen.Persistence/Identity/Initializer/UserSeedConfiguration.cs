using Microsoft.Extensions.Configuration;

namespace Leagueen.Persistence.Identity.Initializer
{
    public class UserSeedConfiguration
    {
        private readonly IConfiguration configuration;

        public UserSeedConfiguration(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string Email => configuration["IdentitySeed:Email"];
        public string DisplayName => configuration["IdentitySeed:DisplayName"];
        public string Password => configuration["IdentitySeed:Password"];
        public string ImageUrl => configuration["IdentitySeed:ImageUrl"];
    }
}
