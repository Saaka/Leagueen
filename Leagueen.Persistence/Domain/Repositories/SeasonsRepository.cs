using System.Threading.Tasks;
using Leagueen.Application.Competitions.Repositories;
using Leagueen.Domain.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Leagueen.Persistence.Domain.Repositories
{
    public class SeasonsRepository : ISeasonsRepository
    {
        private readonly AppDbContext context;

        public SeasonsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task SaveSeason(Season season)
        {
            context.Attach(season);
            await context.SaveChangesAsync();
        }
    }
}
