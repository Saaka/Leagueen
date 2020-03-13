﻿using Leagueen.Application.Competitions.Repositories;
using Leagueen.Application.Friends.Repositories;
using Leagueen.Application.Groups.Repositories;
using Leagueen.Application.Infrastructure.DbInitializer;
using Leagueen.Application.Matches.Repositories;
using Leagueen.Application.UpdateLogs.Repositories;
using Leagueen.Application.Users.Repositories;
using Leagueen.Persistence.Connections;
using Leagueen.Persistence.Domain;
using Leagueen.Persistence.Domain.Initializer;
using Leagueen.Persistence.Domain.Queries;
using Leagueen.Persistence.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leagueen.Persistence
{
    public static class PersistenceModule
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(PersistenceConstants.AppConnectionString);
            RegisterContext<AppDbContext>(services, connectionString, PersistenceConstants.DefaultMigrationsTable);

            return services;
        }

        private static void RegisterContext<T>(IServiceCollection services, string connectionString, string migrationsTable)
            where T : DbContext
        {
            services.AddDbContext<T>((opt) =>
            opt.UseSqlServer(
                connectionString,
                cb =>
                {
                    cb.MigrationsHistoryTable(migrationsTable);
                }),
            ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services
                .AddTransient<IUsersRepository, UsersRepository>()
                .AddTransient<IDbInitializer, AppDbInitializer>()

                .AddTransient<ICompetitionsAggregateRepository, CompetitionsAggregateRepository>()
                .AddTransient<IGroupAggregateRepository, GroupAggregateRepository>()
                .AddTransient<IFriendshipAggregateRepository, FriendshipAggregateRepository>()
                .AddTransient<IUserAggregateRepository, UserAggregateRepository>()

                .AddTransient<ICompetitionsRepository, CompetitionsRepository>()
                .AddTransient<ISeasonsRepository, SeasonsRepository>()
                .AddTransient<ITeamsRepository, TeamsRepository>()
                .AddTransient<IMatchesRepository, MatchesRepository>()
                .AddTransient<IUpdateLogsRepository, UpdateLogsRepository>()
                .AddTransient<IUserGroupsRepository, UserGroupsRepository>()
                .AddTransient<IFriendshipRequestsRepository, FriendshipRequestsRepository>()
                .AddTransient<IUsersRepository, UsersRepository>()

                .AddTransient<IDbConnectionFactory, SqlConnectionFactory>()
                .AddTransient<IGetMatchesByDateQueryExecutor, GetMatchesByDateQueryExecutor>()

                .AddTransient<CompetitionsSeeder>();

            return services;
        }
    }
}
