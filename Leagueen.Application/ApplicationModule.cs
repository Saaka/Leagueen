using Leagueen.Application.Infrastructure;
using Leagueen.Application.Infrastructure.Jobs;
using Leagueen.Application.Matches;
using Leagueen.Application.Matches.Commands;
using Leagueen.Application.Teams;
using Leagueen.Application.UpdateLogs;
using Leagueen.Application.UpdateLogs.UpdateTrackers;
using MediatR;
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
                .AddTransient<IScoreUpdater, ScoreUpdater>()
                .AddTransient<ITeamFactory, TeamFactory>()

                .AddTransient<IUpdateTrackerFactory, UpdateTrackerFactory>()
                .AddTransient<IUpdateTracker<UpdateCurrentMatchesCommand, Unit>, CurrentMatchesUpdateTracker>()
                .AddTransient<IUpdateTracker<UpdateAllSeasonMatchesCommand, Unit>, CompetitionUpdateTracker>()

                .AddTransient<ICompetitionJobsConfiguration, CompetitionJobsConfiguration>()
                ;

            return services;
        }

        public static IServiceCollection AddMediatrBehaviors(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(TrackableRequestBahavior<,>));

            return services;
        }
    }
}
