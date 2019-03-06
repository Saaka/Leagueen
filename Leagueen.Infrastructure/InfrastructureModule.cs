using Leagueen.Application.Security;
using Leagueen.Application.Security.Google;
using Leagueen.Common;
using Leagueen.Infrastructure.Http;
using Leagueen.Infrastructure.Security;
using Leagueen.Infrastructure.Security.Google;
using Microsoft.Extensions.DependencyInjection;

namespace Leagueen.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services
                .AddTransient<IJwtTokenFactory, JwtTokenFactory>()
                .AddTransient<IDateTime, UtcDateProvider>()
                .AddTransient<IGuid, GuidProvider>()
                .AddTransient<IRestsharpClientFactory, RestsharpClientFactory>()
                .AddTransient<IGoogleApiClient, GoogleApiClient>();

            return services;
        }
    }
}
