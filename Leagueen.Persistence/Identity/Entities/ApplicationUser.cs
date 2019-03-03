using Leagueen.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Leagueen.Persistence.Identity.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string DisplayName { get; set; }
        public string Moniker { get; set; }
        public string GoogleId { get; set; }
        public string ImageUrl { get; set; }
    }
}
