using Leagueen.Common;
using Leagueen.Infrastructure.Providers.FootballData;
using Microsoft.Extensions.Configuration;

namespace Leagueen.WebAPI.Configuration
{
    public class ApplicationSettings : IAuthConfiguration, IIdentityIssuerConfiguration
    {
        public const string AuthSecretProperty = "Auth:Secret";
        public const string AuthIssuerProperty = "Auth:Issuer";

        public const string AppConnectionString = "ConnectionStrings:AppConnectionString";

        public const string FootballDataApiToken = "FootballData:ApiToken";
        public const string FootballDataApiUrl = "FootballData:ApiUrl";
        public const string FootballDataApiPlan = "FootballData:ApiPlan";

        public const string IdentityIssuerAppCode = "IdentityIssuer:AppCode";
        public const string IdentityIssuerApiUrl = "IdentityIssuer:ApiUrl";

        private readonly IConfiguration configuration;

        public ApplicationSettings(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string Secret => configuration[AuthSecretProperty];

        public string Issuer => configuration[AuthIssuerProperty];

        public string AppCode => configuration[IdentityIssuerAppCode];
        public string ApiUrl => configuration[IdentityIssuerApiUrl];
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
