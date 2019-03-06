using Leagueen.Common;
using Microsoft.Extensions.Configuration;
using System;

namespace Leagueen.WebAPI.Configuration
{
    public class ApplicationSettings : IAuthConfiguration, IGoogleConfiguration
    {
        public const string AuthSecretProperty = "Auth:Secret";
        public const string AuthIssuerProperty = "Auth:Issuer";
        public const string TokenExpirationProperty = "Auth:ExpirationInMinutes";

        public const string AppConnectionString = "ConnectionStrings:AppConnectionString";

        public const string GoogleClientIdProperty = "Google:ClientId";
        public const string GoogleClientKeyProperty = "Google:ClientKey";
        public const string GoogleValidationEndpointProperty = "Google:ValidationEndpoint";

        private readonly IConfiguration configuration;

        public ApplicationSettings(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string Secret => configuration[AuthSecretProperty];

        public string Issuer => configuration[AuthIssuerProperty];

        public int TokenExpirationDurationInMinutes => Convert.ToInt32(configuration[TokenExpirationProperty]);

        public string ClientId => configuration[GoogleClientIdProperty];

        public string ClientKey => configuration[GoogleClientKeyProperty];

        public string ValidationEndpoint => configuration[GoogleValidationEndpointProperty];
    }
}
