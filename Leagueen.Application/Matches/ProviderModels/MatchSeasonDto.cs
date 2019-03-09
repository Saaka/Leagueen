using System;

namespace Leagueen.Application.Matches.ProviderModels
{
    public class MatchSeasonDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CurrentMatchday { get; set; }
        public MatchTeamDto Winner { get; set; }
    }
}
