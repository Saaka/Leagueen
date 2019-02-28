using Microsoft.Extensions.Logging;
using System;

namespace Leagueen.WebAPI.Jobs
{
    public class LeagueenTestJob
    {
        private readonly ILogger<LeagueenTestJob> logger;

        public LeagueenTestJob(ILogger<LeagueenTestJob> logger)
        {
            this.logger = logger;
        }

        public void Run()
        {
            logger.LogInformation($"{nameof(LeagueenTestJob)} - {DateTime.UtcNow.ToString()} - Running test job");
        }
    }
}
