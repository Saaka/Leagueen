using Leagueen.Application.Infrastructure.DbInitializer;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Leagueen.Persistence.Domain.Initializer
{
    public class AppDbInitializer : IDbInitializer
    {
        private readonly AppDbContext context;
        private readonly CompetitionsSeeder competitionsSeeder;

        public AppDbInitializer(
            AppDbContext context,
            CompetitionsSeeder competitionsSeeder)
        {
            this.context = context;
            this.competitionsSeeder = competitionsSeeder;
        }

        public async Task ExecuteAsync()
        {
            await context.Database.MigrateAsync();
            await competitionsSeeder.ExecuteAsync();
        }
    }
}
