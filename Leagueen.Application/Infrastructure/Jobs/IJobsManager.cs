using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Leagueen.Application.Infrastructure.Jobs
{
    public interface IJobsManager
    {
        void RegisterDailyTask<T>(string taskId, Expression<Func<T, Task>> jobExecution, JobExecutionTime executionTime);
    }
}
