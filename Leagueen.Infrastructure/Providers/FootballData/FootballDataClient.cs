using System.Threading.Tasks;
using Leagueen.Application.Competitions;
using Leagueen.Application.Competitions.ProviderModels;
using Leagueen.Application.Exceptions;
using Leagueen.Application.Matches;
using Leagueen.Application.Matches.ProviderModels;
using Leagueen.Infrastructure.Http;
using RestSharp;

namespace Leagueen.Infrastructure.Providers.FootballData
{
    public class FootballDataClient : IMatchesProvider, ICompetitionsProvider
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

        public async Task<CompetitionTeamsListDto> GetCompetitionTeamsList(string code)
        {
            var client = CreateClient();
            var request = clientFactory
                .CreateRequest($"competitions/{code}/teams", Method.GET);

            var response = await client.ExecuteTaskAsync<CompetitionTeamsListDto>(request);
            EnsureSuccessfulStatusCode(response);

            return response.Data;
        }

        public async Task<CompetitionsListDto> GetCompetitionsList()
        {
            var client = CreateClient();
            var request = clientFactory
                .CreateRequest("competitions", Method.GET)
                .AddQueryParameter("plan", configuration.ApiPlan);

            var response = await client.ExecuteTaskAsync<CompetitionsListDto>(request);
            EnsureSuccessfulStatusCode(response);

            return response.Data;
        }

        public async Task<MatchListDto> GetTodaysMatches()
        {
            var client = CreateClient();
            var request = clientFactory.CreateRequest("matches", Method.GET);

            var response = await client.ExecuteTaskAsync<MatchListDto>(request);
            EnsureSuccessfulStatusCode(response);

            return response.Data;
        }

        public async Task<MatchListDto> GetAllCompetitionMatches(string competitionCode)
        {
            var client = CreateClient();
            var request = clientFactory
                .CreateRequest($"competitions/{competitionCode}/matches", Method.GET);

            var response = await client.ExecuteTaskAsync<MatchListDto>(request);
            EnsureSuccessfulStatusCode(response);

            return response.Data;
        }

        private void EnsureSuccessfulStatusCode<T>(IRestResponse<T> response)
            where T : class
        {
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new ProviderCommunicationException(response.ErrorMessage ?? response.StatusCode.ToString());
        }

        private IRestClient CreateClient()
        {
            var client = clientFactory.CreateClient(configuration.ApiUrl);
            client.AddDefaultHeader("X-Auth-Token", configuration.ApiToken);

            return client;
        }
    }
}
