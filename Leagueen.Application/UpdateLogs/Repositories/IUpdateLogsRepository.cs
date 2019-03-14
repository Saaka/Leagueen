using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using System.Threading.Tasks;

namespace Leagueen.Application.UpdateLogs.Repositories
{
    public interface IUpdateLogsRepository
    {
        Task<UpdateLog> GetLastUpdateLog(UpdateLogType type);
        Task SaveUpdateLog(UpdateLog log);
    }
}
