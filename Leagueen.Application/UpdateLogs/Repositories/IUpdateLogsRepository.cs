using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leagueen.Application.UpdateLogs.Repositories
{
    public interface IUpdateLogsRepository
    {
        Task<UpdateLog> GetLastUpdateLog(UpdateLogType type, DataProviderType provider);
        Task<IEnumerable<UpdateLog>> GetCompetitionUpdatesForProvider(DataProviderType providerType, DateTime date);
        Task SaveUpdateLog(UpdateLog log);
    }
}
