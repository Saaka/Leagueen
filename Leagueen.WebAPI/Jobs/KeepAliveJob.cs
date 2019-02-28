using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leagueen.WebAPI.Jobs
{
    public class KeepAliveJob
    {
        private readonly ILogger<KeepAliveJob> logger;

        public KeepAliveJob(ILogger<KeepAliveJob> logger)
        {
            this.logger = logger;
        }

        public void Run()
        {
            logger.LogInformation($"Leagueen - {nameof(KeepAliveJob)} - {DateTime.UtcNow.ToString()}");
        }
    }
}
