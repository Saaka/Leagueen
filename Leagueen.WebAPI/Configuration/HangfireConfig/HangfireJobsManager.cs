using Hangfire;
using Leagueen.Application.Infrastructure.Jobs;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Leagueen.WebAPI.Configuration.HangfireConfig
{
    public class HangfireJobsManager : IJobsManager
    {
        public void RegisterDailyTask<T>(string taskId, Expression<Func<T, Task>> jobExecution, JobExecutionTime executionTime)
        {
            RecurringJob.AddOrUpdate<T>(taskId, jobExecution, Cron.Daily(executionTime.Hour, executionTime.Miniutes), TimeZoneInfo.Utc);
        }
    }
}
