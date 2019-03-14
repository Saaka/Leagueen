using Leagueen.Application.Matches;
using Microsoft.Extensions.DependencyInjection;

namespace Leagueen.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            services
                .AddTransient<IMatchFactory, MatchFactory>()
                .AddTransient<IMatchUpdater, MatchUpdater>()
                .AddTransient<IScoreFactory, ScoreFactory>()
                .AddTransient<IScoreUpdater, ScoreUpdater>();

            return services;
        }
    }
}
