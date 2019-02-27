using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace Leagueen.WebAPI.Configuration
{
    public static class StartupConfiguration
    {
        public static IWebHostBuilder ConfigureStartup(this IWebHostBuilder builder)
        {
            builder
                .ConfigureLogging(log =>
                {
                    log.AddConsole();
                });

            return builder;
        }
    }
}
