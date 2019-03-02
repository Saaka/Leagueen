using Leagueen.Application.Security;
using Leagueen.Infrastructure.Security;
using Microsoft.Extensions.DependencyInjection;

namespace Leagueen.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services
                .AddTransient<IJwtTokenFactory, JwtTokenFactory>();

            return services;
        }
    }
}
