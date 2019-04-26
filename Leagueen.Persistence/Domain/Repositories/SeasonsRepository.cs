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

        public async Task<Season> GetCurrentSeason(string competitionCode)
        {
            var query = from comp in context.Competitions
                        join season in context.Seasons on comp.CompetitionId equals season.CompetitionId
                        where season.IsActive && comp.Code == competitionCode
                        select season;

            return await query
                .IncludeSeasonData()
                .FirstOrDefaultAsync();
        }

        public async Task<Season> GetSeasonInfo(int seasonId)
        {
            var query = context.Seasons
                .Where(x => x.SeasonId == seasonId)
                .IncludeSeasonData();

            return await query.FirstOrDefaultAsync();
        }

        public async Task SaveSeason(Season season)
        {
            context.Attach(season);
            await context.SaveChangesAsync();
        }
    }

    internal static class SeasonIncludes
    {
        public static IQueryable<Season> IncludeSeasonData(this IQueryable<Season> query)
        {
            return query
                .Include(x => x.Competition)
                    .ThenInclude(x => x.DataProvider)
                .Include(x => x.Matches)
                    .ThenInclude(x => x.MatchScore)
                .Include(x => x.Teams)
                    .ThenInclude(x => x.Team)
                        .ThenInclude(x => x.ExternalMappings);
        }
    }
}
