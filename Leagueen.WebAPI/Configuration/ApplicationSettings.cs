using Leagueen.Common;
using Leagueen.Infrastructure.Providers.FootballData;
using Microsoft.Extensions.Configuration;
using System;

namespace Leagueen.WebAPI.Configuration
{
    public class ApplicationSettings : IAuthConfiguration, IGoogleConfiguration, IFacebookConfiguration
    {
        public const string AuthSecretProperty = "Auth:Secret";
        public const string AuthIssuerProperty = "Auth:Issuer";
        public const string TokenExpirationProperty = "Auth:ExpirationInMinutes";

        public const string AppConnectionString = "ConnectionStrings:AppConnectionString";

        public const string GoogleClientIdProperty = "Google:ClientId";
        public const string GoogleClientKeyProperty = "Google:ClientKey";
        public const string GoogleValidationEndpointProperty = "Google:ValidationEndpoint";

        public const string FootballDataApiToken = "FootballData:ApiToken";
        public const string FootballDataApiUrl = "FootballData:ApiUrl";
        public const string FootballDataApiPlan = "FootballData:ApiPlan";

        public const string FacebookAppIdProperty = "Facebook:AppId";
        public const string FacebookAppSecretProperty = "Facebook:AppSecret";
        public const string FacebookValidationEndpointProperty = "Facebook:ValidationEndpoint";

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

        public string FacebookAppId => configuration[FacebookAppIdProperty];

        public string FacebookAppSecret => configuration[FacebookAppSecretProperty];

        public string FacebookValidationEndpoint => configuration[FacebookValidationEndpointProperty];
    }

    public class FootballDataSettings : IFootballDataConfiguration
    {
        public const string FootballDataApiToken = "FootballData:ApiToken";
        public const string FootballDataApiUrl = "FootballData:ApiUrl";
        public const string FootballDataApiPlan = "FootballData:ApiPlan";

        private readonly IConfiguration configuration;

        public FootballDataSettings(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string ApiToken => configuration[FootballDataApiToken];

        public string ApiUrl => configuration[FootballDataApiUrl];

        public string ApiPlan => configuration[FootballDataApiPlan];
    }
}
