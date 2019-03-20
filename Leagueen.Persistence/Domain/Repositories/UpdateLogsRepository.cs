﻿using Leagueen.Application.UpdateLogs.Repositories;
using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public async Task SaveUpdateLog(UpdateLog log)
        {
            context.Attach(log);
            await context.SaveChangesAsync();
        }
    }
}