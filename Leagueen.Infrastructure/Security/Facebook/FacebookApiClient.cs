using Leagueen.Application.Security;
using Leagueen.Application.Security.Google;
using Leagueen.Common;
using Leagueen.Infrastructure.Http;
using System;
using System.Threading.Tasks;

namespace Leagueen.Infrastructure.Security.Facebook
{
    public class FacebookApiClient : IFacebookApiClient
    {
        private readonly IRestsharpClientFactory restsharpClientFactory;
        private readonly IFacebookConfiguration facebookConfiguration;

        public FacebookApiClient(
            IRestsharpClientFactory restsharpClientFactory,
            IFacebookConfiguration facebookConfiguration)
        {
            this.restsharpClientFactory = restsharpClientFactory;
            this.facebookConfiguration = facebookConfiguration;
        }

        public async Task<TokenInfo> GetTokenInfoAsync(string token)
        {
            throw new NotImplementedException();
        }
    }
}
