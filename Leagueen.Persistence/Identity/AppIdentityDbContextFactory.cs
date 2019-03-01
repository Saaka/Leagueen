using Microsoft.EntityFrameworkCore;

namespace Leagueen.Persistence.Identity
{
    public class AppIdentityDbContextFactory : DesignTimeDbContextFactoryBase<AppIdentityDbContext>
    {
        protected override string MigrationsTable => PersistenceConfig.DefaultIdentityMigrationsTable;

        protected override AppIdentityDbContext CreateNewInstance(DbContextOptions<AppIdentityDbContext> options)
        {
            return new AppIdentityDbContext(options);
        }
    }
}
