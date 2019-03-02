﻿using Hangfire;
using Leagueen.WebAPI.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;

namespace Leagueen.WebAPI.Configuration.DependencyInjection
{
    public static class WebApiRegistrationConfiguration
    {
        public static IServiceCollection AddMvcWithFilters(this IServiceCollection services)
        {
            services
                .AddMvc(o => o.Filters.Add<CustomExceptionFilterAttribute>())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }

        public static IServiceCollection AddExternalAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc(SwaggerVersion, new Swashbuckle.AspNetCore.Swagger.Info
                    {
                        Version = SwaggerVersion,
                        Title = "Leagueen WebAPI",
                        Description = "Create and manage leagues and user bets",
                    });
                })
                .AddHangfire(c =>
                {
                    c.UseSqlServerStorage(configuration["DbSettings:ConnectionString"],
                        new Hangfire.SqlServer.SqlServerStorageOptions
                        {
                            SchemaName = "LeagueenHangFire"
                        });
                })
                .AddTransient<IRestClient, RestClient>();

            return services;
        }

        public static IApplicationBuilder UseExternalAppServices(this IApplicationBuilder application)
        {
            application
                .UseSwagger()
                .UseSwaggerUI(c => c.SwaggerEndpoint($"/swagger/{SwaggerVersion}/swagger.json", "Leaguen WebAPI"))
                .UseHangfireServer()
                .UseHangfireDashboard();

            return application;
        }

        private const string SwaggerVersion = "v0.1";
    }
}