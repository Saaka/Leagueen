using System.Threading.Tasks;
using AutoMapper;
using Leagueen.Application.DataProviders;
using Leagueen.Application.DataProviders.Competitions;
using Leagueen.Application.DataProviders.Matches;
using Leagueen.Application.Exceptions;
using Leagueen.Infrastructure.Http;
using Leagueen.Infrastructure.Providers.FootballData.ProviderModels;
using RestSharp;

namespace Leagueen.Infrastructure.Providers.FootballData
{
    public class FootballDataClient : IMatchesProvider, ICompetitionsProvider
    {
        private readonly IRestsharpClientFactory clientFactory;
        private readonly IFootballDataConfiguration configuration;
        private readonly IMapper mapper;

        public FootballDataClient(
            IRestsharpClientFactory clientFactory,
            IFootballDataConfiguration configuration,
            IMapper mapper)
        {
            this.clientFactory = clientFactory;
            this.configuration = configuration;
            this.mapper = mapper;
        }

        public async Task<CompetitionTeamsListDto> GetCompetitionTeamsList(string code)
        {
            var client = CreateClient();
            var request = clientFactory
                .CreateRequest($"competitions/{code}/teams", Method.GET);

            var response = await client.ExecuteTaskAsync<CompetitionTeamsListModel>(request);
            EnsureSuccessfulStatusCode(response);

            return mapper.Map<CompetitionTeamsListDto>(response.Data);
        }

        public async Task<CompetitionsListDto> GetCompetitionsList()
        {
            var client = CreateClient();
            var request = clientFactory
                .CreateRequest("competitions", Method.GET)
                .AddQueryParameter("plan", configuration.ApiPlan);

            var response = await client.ExecuteTaskAsync<CompetitionsListModel>(request);
            EnsureSuccessfulStatusCode(response);

            return mapper.Map<CompetitionsListDto>(response.Data);
        }

        public async Task<MatchListDto> GetTodaysMatches()
        {
            var client = CreateClient();
            var request = clientFactory.CreateRequest("matches", Method.GET);

            var response = await client.ExecuteTaskAsync<MatchListModel>(request);
            EnsureSuccessfulStatusCode(response);

            return mapper.Map<MatchListDto>(response.Data);
        }

        public async Task<MatchListDto> GetAllCompetitionMatches(string competitionCode)
        {
            var client = CreateClient();
            var request = clientFactory
                .CreateRequest($"competitions/{competitionCode}/matches", Method.GET);

            var response = await client.ExecuteTaskAsync<MatchListModel>(request);
            EnsureSuccessfulStatusCode(response);

            return mapper.Map<MatchListDto>(response.Data);
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
