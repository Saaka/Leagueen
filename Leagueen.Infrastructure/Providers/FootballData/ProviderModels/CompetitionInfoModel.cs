using System;

namespace Leagueen.Infrastructure.Providers.FootballData.ProviderModels
{
    public class CompetitionInfoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
