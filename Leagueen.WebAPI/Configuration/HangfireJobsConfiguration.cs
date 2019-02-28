using Hangfire;
using Microsoft.AspNetCore.Builder;
using System;

namespace Leagueen.WebAPI.Configuration
{
    public static class HangfireJobsConfiguration
    {
        public static IApplicationBuilder ConfigureHangfireJobs(this IApplicationBuilder application)
        {
            RecurringJob.AddOrUpdate<Jobs.LeagueenTestJob>((j) => j.Run(), Cron.Minutely, TimeZoneInfo.Utc);
            RecurringJob.AddOrUpdate<Jobs.KeepAliveJob>((job) => job.Run(), Cron.MinuteInterval(15), TimeZoneInfo.Utc);

            return application;
        }
    }
}
