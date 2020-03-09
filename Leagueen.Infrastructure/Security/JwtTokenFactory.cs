using Leagueen.Application.Security;
using Leagueen.Application.Users.Models;
using Leagueen.Common;
using Leagueen.Domain.Constants;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
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

        public string Create(UserDto user)
        {
            var key = Encoding.ASCII.GetBytes(configuration.Secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = new List<Claim>
            {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserGuid),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            if (user.IsAdmin)
                claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, UserRoles.Admin));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.Now.AddMinutes(configuration.TokenExpirationDurationInMinutes),
                Issuer = configuration.Issuer,
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
