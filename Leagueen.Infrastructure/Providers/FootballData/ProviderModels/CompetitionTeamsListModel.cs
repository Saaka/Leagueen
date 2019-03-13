using System.Collections.Generic;

namespace Leagueen.Infrastructure.Providers.FootballData.ProviderModels
{
    public class CompetitionTeamsListModel
    {
        public CompetitionTeamsListModel()
        {
            Teams = new List<TeamModel>();
        }
        public int Count { get; set; }
        public CompetitionInfoModel Competition { get; set; }
        public CompetitionSeasonModel Season { get; set; }
        public List<TeamModel> Teams { get; set; }
    }
}
