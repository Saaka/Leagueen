using Leagueen.Application.Competitions.Repositories;
using Leagueen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Leagueen.Persistence.Domain.Repositories
{
    public class CompetitionsRepository : ICompetitionsRepository
    {
        private readonly AppDbContext context;

        public CompetitionsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Competition>> GetAllActiveCompetitions()
        {
            return await context
                .Competitions
                .Where(x => x.IsActive)
                .Include(x => x.Seasons)
                    .ThenInclude(x => x.Teams)
                        .ThenInclude(x => x.Team)
                .ToListAsync();
        }

        public async Task<Competition> GetCompetitionByCode(string code)
        {
            return await context
                .Competitions
                .Where(x => x.IsActive)
                .Where(x => x.Code == code)
                .Include(c => c.Seasons)
                    .ThenInclude(x => x.Teams)
                        .ThenInclude(x => x.Team)
                .FirstOrDefaultAsync();
        }

        public async Task SaveCompetition(Competition competition)
        {
            context.Attach(competition);
            await context.SaveChangesAsync();
        }

        public async Task SaveCompetitions(IEnumerable<Competition> competitions)
        {
            competitions.Select(x => context.Attach(x));
            await context.SaveChangesAsync();
        }
    }
}
