using Leagueen.Application.Security;
using Leagueen.Common;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Leagueen.Infrastructure.Security
{
    public class JwtTokenFactory : IJwtTokenFactory
    {
        private readonly IAuthConfiguration configuration;
        private const string AdminClaimName = "admin";

        public JwtTokenFactory(IAuthConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string Create(string moniker, bool isAdmin)
        {
            var key = Encoding.ASCII.GetBytes(configuration.Secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, moniker),
                    new Claim(AdminClaimName, isAdmin.ToString(), ClaimValueTypes.Boolean)
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.Now.AddMinutes(configuration.TokenExpirationDurationInMinutes),
                Issuer = configuration.Issuer,
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
