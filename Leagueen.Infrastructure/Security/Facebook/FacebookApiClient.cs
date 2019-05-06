using Leagueen.Application.Exceptions;
using Leagueen.Application.Security;
using Leagueen.Application.Security.Google;
using Leagueen.Common;
using Leagueen.Domain.Exceptions;
using Leagueen.Infrastructure.Http;
using Leagueen.Infrastructure.Security.Facebook.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Leagueen.Infrastructure.Security.Facebook
{
    public class FacebookApiClient : IFacebookApiClient
    {
        private readonly IRestsharpClientFactory clientFactory;
        private readonly IFacebookConfiguration facebookConfiguration;

        public FacebookApiClient(
            IRestsharpClientFactory clientFactory,
            IFacebookConfiguration facebookConfiguration)
        {
            this.clientFactory = clientFactory;
            this.facebookConfiguration = facebookConfiguration;
        }

        public async Task<TokenInfo> GetTokenInfoAsync(string token)
        {
            var client = clientFactory.CreateClient(facebookConfiguration.FacebookValidationEndpoint);
            var appAccessToken = await GetAppAccessToken(client);
            var verifyTokenResult = await VerifyToken(client, token, appAccessToken);

            return new TokenInfo
            {
            };
        }

        private async Task<FbVerifyTokenResultData> VerifyToken(IRestClient client, string token, string appAccessToken)
        {
            var request = clientFactory.CreateRequest(
                $"debug_token?" +
                $"input_token={token}" +
                $"&access_token={appAccessToken}", Method.GET);

            var response = await client.ExecuteTaskAsync<FbVerifyTokenResult>(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new ProviderCommunicationException(response.ErrorMessage ?? response.StatusCode.ToString());
            if (!response.Data.Data.Scopes.Contains("email"))
                throw new DomainException(Domain.Enums.ExceptionCode.FacebookTokenEmailPermissionRequired);

            return response.Data.Data;
        }

        private async Task<string> GetAppAccessToken(IRestClient client)
        {
            var request = clientFactory.CreateRequest(
                $"oauth/access_token?" +
                $"client_id={facebookConfiguration.FacebookAppId}" +
                $"&client_secret={facebookConfiguration.FacebookAppSecret}" +
                $"&grant_type=client_credentials",
                Method.GET);

            var response = await client.ExecuteTaskAsync<FbAccessTokenResponse>(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new ProviderCommunicationException(response.ErrorMessage ?? response.StatusCode.ToString());

            return response.Data.AccessToken;
        }
    }
}
