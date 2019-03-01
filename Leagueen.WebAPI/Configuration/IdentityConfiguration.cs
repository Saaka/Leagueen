using Leagueen.Persistence.Identity;
using Leagueen.Persistence.Identity.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Leagueen.WebAPI.Configuration
{
    public static class IdentityConfiguration
    {
        public const string AuthSecretProperty = "Auth:Secret";
        public const string AuthIssuerProperty = "Auth:Issuer";
        public const string AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

        public static IServiceCollection AddJwtTokenBearerAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var secret = configuration[AuthSecretProperty];
            var key = Encoding.ASCII.GetBytes(secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),

                    ValidateIssuer = true,
                    ValidIssuer = configuration[AuthIssuerProperty],

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
                    opt.User.RequireUniqueEmail = true;
                    opt.User.AllowedUserNameCharacters = AllowedUserNameCharacters;
                    opt.Password.RequireDigit = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireNonAlphanumeric = false;
                })
                .AddUserStore<UserStore<ApplicationUser, IdentityRole<int>, AppIdentityDbContext, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityUserToken<int>, IdentityRoleClaim<int>>>()
                ;
            
            return services;
        }
    }
}
