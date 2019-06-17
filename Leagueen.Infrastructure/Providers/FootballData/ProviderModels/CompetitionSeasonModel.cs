using System;

namespace Leagueen.Infrastructure.Providers.FootballData.ProviderModels
{
    public class CompetitionSeasonModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? CurrentMatchday { get; set; }
        public TeamSimpleModel Winner { get; set; }
    }
}
