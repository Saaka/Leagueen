using Leagueen.Common;
using Leagueen.Infrastructure;
using Leagueen.Persistence;
using Leagueen.WebAPI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Leagueen.WebAPI.Configuration.DependencyInjection
{
    public static class ApplicationRegistrationConfiguration
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services
                .AddTransient<IAuthConfiguration, ApplicationSettings>()
                .AddTransient<IGoogleConfiguration, ApplicationSettings>()

                .AddTransient<IUserContextDataProvider, UserContextDataProvider>();

            services
                .AddInfrastructure()
                .AddPersistence();

            return services;
        }
    }
}
