using Leagueen.Common;
using Leagueen.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Leagueen.WebAPI.Configuration.DependencyInjection
{
    public static class ApplicationRegistrationConfiguration
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services
                .AddTransient<IAuthConfiguration, ApplicationConfiguration>();
            
            services
                .AddInfrastructure();

            return services;
        }
    }
}
