using AutoMapper;
using FluentValidation.AspNetCore;
using Hangfire;
using Leagueen.Application;
using Leagueen.Application.Infrastructure;
using Leagueen.Application.Infrastructure.AutoMapper;
using Leagueen.Infrastructure;
using Leagueen.Persistence;
using Leagueen.WebAPI.Filters;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;
using System.Reflection;

namespace Leagueen.WebAPI.Configuration.DependencyInjection
{
    public static class WebApiRegistrationConfiguration
    {
        public static IServiceCollection AddMvcWithFilters(this IServiceCollection services)
        {
            services
                .AddMvc(options =>
                {
                    options.Filters.Add<CustomExceptionFilterAttribute>();
                })
                .AddJsonOptions(s => s.UseCamelCasing(true))
                .AddFluentValidation(v => v.RegisterValidatorsFromAssembly(typeof(ApplicationModule).Assembly))
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
                .AddAutoMapper(new Assembly[]
                {
                    typeof(AppAutoMapperProfile).Assembly,
                    typeof(InfrastructureAutoMapperProfile).Assembly,
                    typeof(PersistenceAutoMapperProfile).Assembly
                })
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
                    c.UseSqlServerStorage(configuration[ApplicationSettings.AppConnectionString],
                        new Hangfire.SqlServer.SqlServerStorageOptions
                        {
                            SchemaName = "LeagueenHangFire"
                        });
                })
                .AddTransient<IRestClient, RestClient>()
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>))
                .AddMediatR(typeof(ApplicationModule).Assembly);

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
