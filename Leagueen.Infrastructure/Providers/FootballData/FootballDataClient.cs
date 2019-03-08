using System.Threading.Tasks;
using Leagueen.Application.Exceptions;
using Leagueen.Application.Matches;
using Leagueen.Application.Matches.Models;
using Leagueen.Infrastructure.Http;
using RestSharp;

namespace Leagueen.Infrastructure.Providers.FootballData
{
    public class FootballDataClient : IMatchesProvider
    {
        private readonly IRestsharpClientFactory clientFactory;
        private readonly IFootballDataConfiguration configuration;

        public FootballDataClient(
            IRestsharpClientFactory clientFactory,
            IFootballDataConfiguration configuration)
        {
            this.clientFactory = clientFactory;
            this.configuration = configuration;
        }

        public async Task<MatchListDto> GetTodaysMatches()
        {
            var client = CreateClient();
            var request = clientFactory.CreateRequest("matches", Method.GET);

            var response = await client.ExecuteTaskAsync<MatchListDto>(request);
            if(response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new ProviderCommunicationException(response.ErrorMessage ?? response.StatusCode.ToString());

            return response.Data;
        }

        private IRestClient CreateClient()
        {
            var client = clientFactory.CreateClient(configuration.ApiUrl);
            client.AddDefaultHeader("X-Auth-Token", configuration.ApiToken);

            return client;
        }
    }
}
