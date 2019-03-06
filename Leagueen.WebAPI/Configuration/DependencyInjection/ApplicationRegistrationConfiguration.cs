using Leagueen.Common;
using Leagueen.Infrastructure;
using Leagueen.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Leagueen.WebAPI.Configuration.DependencyInjection
{
    public static class ApplicationRegistrationConfiguration
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services
                .AddTransient<IAuthConfiguration, ApplicationSettings>()
                .AddTransient<IGoogleConfiguration, ApplicationSettings>();
            
            services
                .AddInfrastructure()
                .AddPersistence();

            return services;
        }
    }
}
