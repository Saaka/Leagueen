using System;

namespace Leagueen.Application.Competitions.ProviderModels
{
    public class CompetitionSeasonDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CurrentMatchday { get; set; }
        public CompetitionTeamDto Winner { get; set; }

    }
}
