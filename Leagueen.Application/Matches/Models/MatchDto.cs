using System;

namespace Leagueen.Application.Matches.Models
{
    public class MatchDto
    {
        public int Id { get; set; }
        public MatchCompetitionDto Competition { get; set; }
        public DateTime UtcDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Status { get; set; }
        public int Matchday { get; set; }
        public string Stage { get; set; }
        public MatchScoreDto Score { get; set; }
        public MatchTeamDto HomeTeam { get; set; }
        public MatchTeamDto AwayTeam { get; set; }
    }
}
