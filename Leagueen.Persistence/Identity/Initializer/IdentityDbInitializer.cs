using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Leagueen.Persistence.Identity.Initializer
{
    public class IdentityDbInitializer
    {
        private readonly AppIdentityDbContext context;
        private readonly UserSeeder userSeeder;

        public IdentityDbInitializer(
            AppIdentityDbContext context,
            UserSeeder userSeeder)
        {
            this.context = context;
            this.userSeeder = userSeeder;
        }

        public async Task ExecuteAsync()
        {
            await context.Database.MigrateAsync();
            await userSeeder.ExecuteAsync();
        }
    }
}
