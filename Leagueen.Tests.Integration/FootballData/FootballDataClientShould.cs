using Leagueen.Domain.Enums;
using Leagueen.Infrastructure.Http;
using Leagueen.Infrastructure.Providers.FootballData;
using System.Threading.Tasks;
using Xunit;

namespace Leagueen.Tests.Integration.FootballData
{
    [Trait("Integration", "FootballData")]
    public class FootballDataClientShould
    {
        [Fact]
        public async Task ReturnTodaysMatches()
        {
            var client = CreateClient();

            var result = await client.GetTodaysMatches();

            Assert.NotNull(result);
            Assert.NotEqual(0, result.Count);
        }

        [Fact]
        public async Task ReturnAllCompetitionMatches()
        {
            var client = CreateClient();

            var result = await client.GetAllCompetitionMatches(CompetitionType.PL.ToString());

            Assert.NotNull(result);
            Assert.NotEqual(0, result.Count);
        }

        [Fact]
        public async Task ReturnAvailableCopetitions()
        {
            var client = CreateClient();

            var result = await client.GetCompetitionsList();

            Assert.NotNull(result);
            Assert.NotEqual(0, result.Count);
        }

        [Fact]
        public async Task ReturnCompetitionTeams()
        {
            var client = CreateClient();

            var result = await client.GetCompetitionTeamsList("PL");

            Assert.NotNull(result);
            Assert.NotEqual(0, result.Count);
        }

        private FootballDataClient CreateClient()
        {
            return new FootballDataClient(
                new RestsharpClientFactory(),
                TestConfiguration.Create());
        }
    }
}
