using Hangfire;
using Leagueen.Domain.Enums;
using Leagueen.WebAPI.Jobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;

namespace Leagueen.WebAPI.Configuration.HangfireConfig
{
    public static class HangfireJobsConfiguration
    {
        public static IApplicationBuilder ConfigureApplicationJobs(this IApplicationBuilder application, IConfiguration configuration)
        {
            RecurringJob.AddOrUpdate<CurrentMatchesUpdaterJob>(
                $"CurrentMatchesUpdaterJob_{DataProviderType.FootballData.ToString()}",
                j => j.Run(DataProviderType.FootballData), Cron.Minutely(), TimeZoneInfo.Utc);

            RecurringJob.AddOrUpdate<CompetitionsUpdateJob>(
                $"CompetitionsUpdateJob_{DataProviderType.FootballData.ToString()}",
                j => j.Run(DataProviderType.FootballData), Cron.MinuteInterval(5), TimeZoneInfo.Utc);

            return application;
        }

        public static IApplicationBuilder ConfigureKeepAliveJob(this IApplicationBuilder application, IConfiguration configuration)
        {
            if (Convert.ToBoolean(configuration["APIInfrastructure:UseKeepAlive"]))
                RecurringJob.AddOrUpdate<KeepAliveJob>((job) => job.Run(), Cron.MinuteInterval(15), TimeZoneInfo.Utc);
            else
                RecurringJob.RemoveIfExists("KeepAliveJob.Run");

            return application;
        }
    }
}
