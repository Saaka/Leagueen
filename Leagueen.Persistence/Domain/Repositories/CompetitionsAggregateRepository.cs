using Leagueen.Application.Competitions.Repositories;
using Leagueen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leagueen.Persistence.Domain.Repositories
{
    public class CompetitionsAggregateRepository : ICompetitionsAggregateRepository
    {
        private readonly AppDbContext context;

        public CompetitionsAggregateRepository(AppDbContext context)
        {
            this.context = context;
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

        public async Task<Competition> GetCompetitionByCode(string code)
        {
            return await context
                .Competitions
                .Where(x => x.Code == code)
                .IncludeCompetitionsData()
                .FirstOrDefaultAsync();
        }
    }

    internal static class CompetitionIncludes
    {
        public static IQueryable<Competition> IncludeCompetitionsData(this IQueryable<Competition> query)
        {
            return query
                .Include(x => x.DataProvider)
                .Include(c => c.Seasons)
                    .ThenInclude(x => x.Teams)
                        .ThenInclude(x => x.Team)
                            .ThenInclude(x => x.ExternalMappings);
        }
    }
}
