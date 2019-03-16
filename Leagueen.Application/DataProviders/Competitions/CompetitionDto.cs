using System;

namespace Leagueen.Application.DataProviders.Competitions
{
    public class CompetitionDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime LastUpdated { get; set; }
        public CompetitionSeasonDto CurrentSeason { get; set; }
    }
}
