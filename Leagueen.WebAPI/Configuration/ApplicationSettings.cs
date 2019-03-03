using Leagueen.Common;
using Microsoft.Extensions.Configuration;
using System;

namespace Leagueen.WebAPI.Configuration
{
    public class ApplicationSettings : IAuthConfiguration
    {
        public const string AuthSecretProperty = "Auth:Secret";
        public const string AuthIssuerProperty = "Auth:Issuer";
        public const string TokenExpirationProperty = "Auth:ExpirationInMinutes";

        public const string AppConnectionString = "ConnectionStrings:AppConnectionString";

        private readonly IConfiguration configuration;

        public ApplicationSettings(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string Secret => configuration[AuthSecretProperty];

        public string Issuer => configuration[AuthIssuerProperty];

        public int TokenExpirationDurationInMinutes => Convert.ToInt32(configuration[TokenExpirationProperty]);
    }
}
