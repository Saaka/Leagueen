using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Leagueen.WebAPI.Configuration.DependencyInjection
{
    public static class IdentityRegistrationConfiguration
    {
        public static IServiceCollection AddJwtTokenBearerAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var secret = configuration[ApplicationSettings.AuthSecretProperty];
            var key = Encoding.ASCII.GetBytes(secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),

                    ValidateIssuer = true,
                    ValidIssuer = configuration[ApplicationSettings.AuthIssuerProperty],

                    ValidateAudience = false
                };
            });

            return services;
        }
    }
}
