using Leagueen.Application.Matches.Repositories;
using Leagueen.Domain.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Leagueen.Persistence.Domain.Repositories
{
    public class MatchesRepository : IMatchesRepository
    {
        private readonly AppDbContext context;

        public MatchesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Match>> GetAllMatchesByDate(DateTime date)
        {
            var dateFrom = date.Date;
            var dateTo = date.Date.AddDays(1);

            var query = context.Matches
                .Where(x => x.Date >= dateFrom && x.Date < dateTo)
                .Include(x => x.Season)
                .Include(x => x.AwayTeam)
                .Include(x => x.HomeTeam)
                .Include(x => x.MatchScore);

            return await query.ToListAsync();
        }
    }
}
