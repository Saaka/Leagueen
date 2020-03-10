using Leagueen.Application.DataProviders;
using Leagueen.Application.Infrastructure;
using Leagueen.Common;
using Leagueen.Infrastructure.Helpers;
using Leagueen.Infrastructure.Http;
using Leagueen.Infrastructure.Images;
using Leagueen.Infrastructure.Providers.FootballData;
using Leagueen.Infrastructure.Providers.IdentityProvider;
using Microsoft.Extensions.DependencyInjection;

namespace Leagueen.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services
                .AddTransient<IDateTime, UtcDateProvider>()
                .AddTransient<IGuid, GuidProvider>()
                .AddTransient<IRestsharpClientFactory, RestsharpClientFactory>()

                .AddTransient<IMatchesProvider, FootballDataClient>()
                .AddTransient<ICompetitionsProvider, FootballDataClient>()

                .AddTransient<HashGenerator>()
                .AddTransient<IProfileImageUrlProvider, GravatarProfileImageUrlProvider>()

                .AddTransient<IIdentityProvider, IdentityIssuerIdentityProvider>();

            return services;
        }
    }
}
