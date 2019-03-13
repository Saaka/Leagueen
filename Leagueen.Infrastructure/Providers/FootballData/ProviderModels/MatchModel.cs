using System;

namespace Leagueen.Infrastructure.Providers.FootballData.ProviderModels
{
    public class MatchModel
    {
        public int Id { get; set; }
        public CompetitionSimpleModel Competition { get; set; }
        public SeasonSimpleModel Season { get; set; }
        public DateTime UtcDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Status { get; set; }
        public int? Matchday { get; set; }
        public string Stage { get; set; }
        public string Group { get; set; }
        public MatchScoreModel Score { get; set; }
        public TeamSimpleModel HomeTeam { get; set; }
        public TeamSimpleModel AwayTeam { get; set; }
    }
}
