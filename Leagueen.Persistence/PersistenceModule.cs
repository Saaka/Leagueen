using Leagueen.Application.Users.Repositories;
using Leagueen.Persistence.Domain;
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

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services
                .AddTransient<IUsersRepository, UsersRepository>();

            return services;
        }
    }
}
