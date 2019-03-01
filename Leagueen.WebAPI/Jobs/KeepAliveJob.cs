using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;

namespace Leagueen.WebAPI.Jobs
{
    public class KeepAliveJob
    {
        private readonly ILogger<KeepAliveJob> logger;
        private readonly IRestClient restClient;
        private readonly IConfiguration configuration;

        public KeepAliveJob(
            ILogger<KeepAliveJob> logger,
            IRestClient restClient,
            IConfiguration configuration)
        {
            this.logger = logger;
            this.restClient = restClient;
            this.configuration = configuration;
        }

        public void Run()
        {
            logger.LogInformation($"Leagueen - {nameof(KeepAliveJob)} - {DateTime.UtcNow.ToString()}");

            var serviceAddress = configuration["APIInfrastructure:UseKeepAlive"];

            var restRequest = new RestRequest(serviceAddress, Method.POST)
                .AddJsonBody(new { ReturnUrl = configuration["APIInfrastructure:PingAddress"] });

            var response = restClient.Execute(restRequest);

            var result = response.Content == configuration["APIInfrastructure:PingAddress"] ? "Success" : "Fail";
            logger.LogInformation($"Leagueen - {nameof(KeepAliveJob)} - {DateTime.UtcNow.ToString()} - {result}");
        }
    }
}
