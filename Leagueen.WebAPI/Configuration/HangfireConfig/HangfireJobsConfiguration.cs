using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;

namespace Leagueen.WebAPI.Configuration.HangfireConfig
{
    public static class HangfireJobsConfiguration
    {
        public static IApplicationBuilder ConfigureKeepAliveJob(this IApplicationBuilder application, IConfiguration configuration)
        {
            if (Convert.ToBoolean(configuration["APIInfrastructure:UseKeepAlive"]))
                RecurringJob.AddOrUpdate<Jobs.KeepAliveJob>((job) => job.Run(), Cron.MinuteInterval(15), TimeZoneInfo.Utc);
            else
                RecurringJob.RemoveIfExists("KeepAliveJob.Run");

            return application;
        }
    }
}
