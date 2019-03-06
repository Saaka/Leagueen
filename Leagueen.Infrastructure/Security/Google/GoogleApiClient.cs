using AutoMapper;
using Leagueen.Application.Exceptions;
using Leagueen.Application.Security;
using Leagueen.Application.Security.Google;
using Leagueen.Common;
using Leagueen.Infrastructure.Http;
using RestSharp;
using System.Threading.Tasks;

namespace Leagueen.Infrastructure.Security.Google
{
    public class GoogleApiClient : IGoogleApiClient
    {
        private readonly IRestsharpClientFactory clientFactory;
        private readonly IGoogleConfiguration googleConfiguration;
        private readonly IMapper mapper;
        private const string TokenInfoAddress = "tokeninfo?id_token=";

        public GoogleApiClient(
            IRestsharpClientFactory restsharpClientFactory,
            IGoogleConfiguration googleConfiguration,
            IMapper mapper)
        {
            this.clientFactory = restsharpClientFactory;
            this.googleConfiguration = googleConfiguration;
            this.mapper = mapper;
        }

        public async Task<TokenInfo> GetTokenInfoAsync(string token)
        {
            var client = clientFactory.CreateClient(googleConfiguration.ValidationEndpoint);
            var request = clientFactory.CreateRequest($"{TokenInfoAddress}{token}", Method.GET);

            var response = await client.ExecuteTaskAsync<GoogleTokenInfo>(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new ProviderCommunicationException(response.ErrorMessage ?? response.StatusCode.ToString());

            return mapper.Map<TokenInfo>(response.Data);
        }
    }
}
