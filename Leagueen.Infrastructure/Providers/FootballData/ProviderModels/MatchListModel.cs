using System.Collections.Generic;

namespace Leagueen.Infrastructure.Providers.FootballData.ProviderModels
{
    public class MatchListModel
    {
        public MatchListModel()
        {
            Matches = new List<MatchModel>();
        }

        public int Count { get; set; }
        public List<MatchModel> Matches { get; set; }
    }
}
