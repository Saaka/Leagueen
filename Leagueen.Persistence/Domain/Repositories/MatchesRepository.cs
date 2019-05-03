using Leagueen.Application.Matches.Repositories;
using Leagueen.Domain.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Leagueen.Domain.Enums;

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

        public async Task<bool> AreMatchesInPlay(DateTime dateTime)
        {
            var dateTimeFrom = dateTime.AddMinutes(-15);
            var dateTimeTo = dateTime.AddMinutes(30);
            var query = from m in context.Matches
                        where ActiveMatchesStatuses.Contains(m.Status)
                            || (m.Date >= dateTimeFrom && m.Date <= dateTimeTo)
                        select m.MatchId;

            return await query.AnyAsync();
        }

        public async Task SaveMatches(List<Match> toSave)
        {
            context.Matches.AttachRange(toSave);
            await context.SaveChangesAsync();
        }

        private MatchStatus[] ActiveMatchesStatuses => new MatchStatus[] { MatchStatus.InPlay, MatchStatus.Paused };
    }
}
