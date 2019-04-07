using Leagueen.Application.UpdateLogs.Repositories;
using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace Leagueen.Persistence.Domain.Repositories
{
    public class UpdateLogsRepository : IUpdateLogsRepository
    {
        private readonly AppDbContext context;

        public UpdateLogsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<UpdateLog> GetLastUpdateLog(UpdateLogType logType, DataProviderType providerType)
        {
            return await context.UpdateLogs
                .Where(x => x.LogType == logType && x.ProviderType == providerType)
                .OrderByDescending(x => x.Date)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UpdateLog>> GetCompetitionUpdatesForProvider(DataProviderType providerType, DateTime date)
        {
            var dateFrom = date.Date;
            var dateTo = date.Date.AddDays(1).Date;
            return await context.UpdateLogs
                .Where(x => x.LogType == UpdateLogType.Competition && x.ProviderType == providerType && (x.Date >= dateFrom && x.Date < dateTo))
                .OrderBy(x=> x.CompetitionType)
                .ToListAsync();
        }

        public async Task SaveUpdateLog(UpdateLog log)
        {
            context.Attach(log);
            await context.SaveChangesAsync();
        }
    }
}
