using Leagueen.Application.Competitions.Repositories;
using Leagueen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Leagueen.Domain.Enums;

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
                .IncludeCompetitionsData()
                .ToListAsync();
        }

        public async Task<IEnumerable<CompetitionType>> GetAllActiveCompetitionTypesForProvider(DataProviderType providerType)
        {
            var query = from comp in context.Competitions
                        join prov in context.DataProviders on comp.DataProviderId equals prov.DataProviderId
                        where prov.Type == providerType && comp.IsActive
                        select comp.Type;

            return await query.ToListAsync();
        }

        public async Task<Competition> GetCompetitionByCode(string code)
        {
            return await context
                .Competitions
                .Where(x => x.Code == code)
                .IncludeCompetitionsData()
                .FirstOrDefaultAsync();
        }

        public async Task<DataProviderType> GetProviderTypeForCompetition(CompetitionType type)
        {
            var query = from c in context.Competitions
                        join p in context.DataProviders on c.DataProviderId equals p.DataProviderId
                        where c.IsActive == true && c.Type == type
                        select p.Type;

            return await query.FirstOrDefaultAsync();
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
