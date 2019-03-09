using Leagueen.Application.Infrastructure.DbInitializer;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Leagueen.Persistence.Domain.Initializer
{
    public class AppDbInitializer : IAppDbInitializer
    {
        private readonly AppDbContext context;
        private readonly ICompetitionsSeeder competitionsSeeder;

        public AppDbInitializer(
            AppDbContext context,
            ICompetitionsSeeder competitionsSeeder)
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
