using Leagueen.Application.Infrastructure.DbInitializer;
using Leagueen.Application.Users.Repositories;
using Leagueen.Persistence.Domain;
using Leagueen.Persistence.Domain.Initializer;
using Leagueen.Persistence.Identity;
using Leagueen.Persistence.Users;
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
            RegisterContext<AppDbContext>(services, connectionString, PersistenceConstants.DefaultMigrationsTable);
            RegisterContext<AppIdentityDbContext>(services, connectionString, PersistenceConstants.DefaultIdentityMigrationsTable);

            return services;
        }

        private static void RegisterContext<T>(IServiceCollection services, string connectionString, string migrationsTable)
            where T : DbContext
        {
            services.AddDbContext<T>((opt) =>
            opt.UseSqlServer(
                connectionString,
                cb =>
                {
                    cb.MigrationsHistoryTable(migrationsTable);
                }),
            ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services
                .AddTransient<IUsersRepository, UsersRepository>()

                .AddTransient<IAppDbInitializer, AppDbInitializer>()
                .AddTransient<ICompetitionsSeeder, CompetitionsSeeder>();

            return services;
        }
    }
}
