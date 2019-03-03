using Leagueen.Persistence.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leagueen.Persistence
{
    public static class PersistenceModule
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(PersistenceConstants.AppConnectionString);
            services.AddDbContext<AppDbContext>((opt) =>
            opt.UseSqlServer(
                connectionString,
                cb =>
                {
                    cb.MigrationsHistoryTable(PersistenceConstants.DefaultMigrationsTable);
                }),
            ServiceLifetime.Scoped);

            return services;
        }
    }
}
