using System;

namespace Leagueen.Application.DataProviders.Competitions
{
    public class CompetitionSeasonDto
    {
        public string Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CurrentMatchday { get; set; }
        public string SeasonWinnerId { get; set; }
    }
}
