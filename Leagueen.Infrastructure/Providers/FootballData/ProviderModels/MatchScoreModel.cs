namespace Leagueen.Infrastructure.Providers.FootballData.ProviderModels
{
    public class MatchScoreModel
    {
        public string Winner { get; set; }
        public string Duration { get; set; }
        public MatchScoreValueModel FullTime { get; set; }
        public MatchScoreValueModel HalfTime { get; set; }
        public MatchScoreValueModel ExtraTime { get; set; }
        public MatchScoreValueModel Penalties { get; set; }
    }
}
