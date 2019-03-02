using Leagueen.Common;
using Microsoft.Extensions.Configuration;
using System;

namespace Leagueen.WebAPI.Configuration
{
    public class ApplicationConfiguration : IAuthConfiguration
    {
        public const string AuthSecretProperty = "Auth:Secret";
        public const string AuthIssuerProperty = "Auth:Issuer";
        public const string TokenExpirationProperty = "Auth:ExpirationInMinutes";

        private readonly IConfiguration configuration;

        public ApplicationConfiguration(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string Secret => configuration[AuthSecretProperty];

        public string Issuer => configuration[AuthIssuerProperty];

        public int TokenExpirationDurationInMinutes => Convert.ToInt32(configuration[TokenExpirationProperty]);
    }
}
