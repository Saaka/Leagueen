using Leagueen.Infrastructure.Providers.FootballData;
using Microsoft.Extensions.Configuration;

namespace Leagueen.Tests.Integration.FootballData
{
    public class TestConfiguration : IFootballDataConfiguration
    {
        public static IFootballDataConfiguration Create()
        {
            return new TestConfiguration(Config.TestsConfiguration.InitConfiguration());
        }

        public const string FootballDataApiToken = "FootballData:ApiToken";
        public const string FootballDataApiUrl = "FootballData:ApiUrl";
        public const string FootballDataApiPlan = "FootballData:ApiPlan";

        private readonly IConfiguration configuration;

        public TestConfiguration(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string ApiToken => configuration[FootballDataApiToken];

        public string ApiUrl => configuration[FootballDataApiUrl];

        public string ApiPlan => configuration[FootballDataApiPlan];
    }
}
