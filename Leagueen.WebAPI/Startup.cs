using Leagueen.Persistence;
using Leagueen.WebAPI.Configuration;
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
                .AddCors()
                .AddMvcWithFilters()
                .AddJwtTokenBearerAuthentication(Configuration)
                .AddDbContext(Configuration)
                .AddIdentityStore(Configuration)
                .AddLogging()
                .AddExternalAppServices(Configuration);
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
                .ConfigureHangfireJobs(Configuration);
        }
    }
}
