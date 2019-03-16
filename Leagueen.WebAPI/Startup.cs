using Leagueen.Persistence;
using Leagueen.WebAPI.Configuration.HangfireConfig;
using Leagueen.WebAPI.Configuration.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leagueen.WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddApplicationDependencies()
                .AddDbContext(Configuration)
                .AddIdentityStore(Configuration)
                .AddExternalAppServices(Configuration)
                .AddCors()
                .AddMvcWithFilters()
                .AddJwtTokenBearerAuthentication(Configuration)
                .AddLogging();
        }

        public void Configure(IApplicationBuilder application, IHostingEnvironment env)
        {
            if (env.IsProduction())
            {
                application.UseHsts();
            }

            application
                .UseCors(x => x
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials())
                .UseExternalAppServices()
                .UseAuthentication()
                .UseMvc()
                .ConfigureKeepAliveJob(Configuration)
                .ConfigureApplicationJobs(Configuration);
        }
    }
}
