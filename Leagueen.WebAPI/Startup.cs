using Leagueen.WebAPI.Configuration;
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
                .RegisterLibraries(Configuration);
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
                .UseAppServices()
                .UseMvc();
        }
    }
}
