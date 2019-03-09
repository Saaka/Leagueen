using Leagueen.Common;
using Leagueen.Domain.Constants;
using Leagueen.Persistence.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Leagueen.Persistence.Identity.Initializer
{
    public class UserSeeder
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;
        private readonly UserSeedConfiguration configuration;
        private readonly IGuid guid;

        public UserSeeder(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole<int>> roleManager,
            UserSeedConfiguration configuration,
            IGuid guid)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
            this.guid = guid;
        }
        public async Task ExecuteAsync()
        {
            var user = await userManager.FindByEmailAsync(configuration.Email);
            if (user != null) return;

            var admin = new ApplicationUser
            {
                Email = configuration.Email,
                UserName = configuration.Email,
                DisplayName = configuration.DisplayName,
                ImageUrl = configuration.ImageUrl,
                Moniker = guid.GetNormalizedGuid(),
            };
            await userManager.CreateAsync(admin, configuration.Password);
            await roleManager.CreateAsync(new IdentityRole<int>(UserRoles.Admin));
            await userManager.AddToRoleAsync(admin, UserRoles.Admin);
        }
    }
}
