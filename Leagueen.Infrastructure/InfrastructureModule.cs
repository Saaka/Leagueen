using Leagueen.Application.Security;
using Leagueen.Common;
using Leagueen.Infrastructure.Security;
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
                .AddTransient<IGuid, GuidProvider>();

            return services;
        }
    }
}
