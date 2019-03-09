using Leagueen.Application.Infrastructure.DbInitializer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Leagueen.WebAPI.Services
{
    public class WebDbInitializer
    {
        public static void Initialize(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<WebDbInitializer>>();
                try
                {
                    logger.LogInformation("Initializing database");
                    var initializer = services.GetRequiredService<IDbInitializer>();
                    initializer.ExecuteAsync().Wait();
                    logger.LogInformation("Database initialization successful");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
        }
    }
}
