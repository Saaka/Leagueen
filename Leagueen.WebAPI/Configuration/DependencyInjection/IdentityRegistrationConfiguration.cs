using Leagueen.Domain.Constants;
using Leagueen.Persistence.Identity;
using Leagueen.Persistence.Identity.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

        public static IServiceCollection AddIdentityStore(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddIdentity<ApplicationUser, IdentityUserRole<int>>(opt =>
                {
                    opt.User = new UserOptions
                    {
                        AllowedUserNameCharacters = UserConstants.AllowedUserNameCharacters,
                        RequireUniqueEmail = true
                    };
                    opt.Password = new PasswordOptions
                    {
                        RequireDigit = false,
                        RequireUppercase = false,
                        RequireNonAlphanumeric = false,
                    };
                })
                .AddUserStore<UserStore<ApplicationUser, IdentityRole<int>, AppIdentityDbContext, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityUserToken<int>, IdentityRoleClaim<int>>>()
                ;
            
            return services;
        }
    }
}
