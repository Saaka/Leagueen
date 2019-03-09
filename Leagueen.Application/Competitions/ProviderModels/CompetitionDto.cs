using System;

namespace Leagueen.Application.Competitions.ProviderModels
{
    public class CompetitionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime LastUpdated { get; set; }
        public CompetitionSeasonDto CurrentSeason { get; set; }
    }
}
