using Microsoft.Extensions.Configuration;

namespace Leagueen.Tests.Integration.Config
{
    public static class TestsConfiguration
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.test.json")
                .Build();
            return config;
        }
    }
}
