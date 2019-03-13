using System.Collections.Generic;

namespace Leagueen.Infrastructure.Providers.FootballData.ProviderModels
{
    public class CompetitionsListModel
    {
        public CompetitionsListModel()
        {
            Competitions = new List<CompetitionModel>();
        }

        public int Count { get; set; }
        public List<CompetitionModel> Competitions { get; set; }
    }
}
