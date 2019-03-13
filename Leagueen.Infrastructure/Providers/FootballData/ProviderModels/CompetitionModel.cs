using System;

namespace Leagueen.Infrastructure.Providers.FootballData.ProviderModels
{
    public class CompetitionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime LastUpdated { get; set; }
        public CompetitionSeasonModel CurrentSeason { get; set; }
    }
}
