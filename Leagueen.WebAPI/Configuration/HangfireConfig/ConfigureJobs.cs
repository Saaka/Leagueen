using Hangfire;
using Leagueen.Application.Competitions.Jobs;
using Leagueen.Domain.Enums;
using Leagueen.WebAPI.Jobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;

namespace Leagueen.WebAPI.Configuration.HangfireConfig
{
    public static class ConfigureJobs
    {
        public static IApplicationBuilder ConfigureApplicationJobs(this IApplicationBuilder application, IConfiguration configuration)
        {
            RecurringJob.AddOrUpdate<CurrentMatchesUpdaterJob>(
                $"CurrentMatchesUpdaterJob_{DataProviderType.FootballData.ToString()}",
                j => j.Run(DataProviderType.FootballData), Cron.Minutely(), TimeZoneInfo.Utc);

            RecurringJob.AddOrUpdate<CompetitionMatchesUpdateJob>(
                $"CompetitionMatchesUpdateJob_{DataProviderType.FootballData.ToString()}",
                j => j.Run(DataProviderType.FootballData), Cron.MinuteInterval(5), TimeZoneInfo.Utc);

            return application;
        }
    }
}
