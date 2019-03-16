using Leagueen.Domain.Enums;
using System;

namespace Leagueen.Application.DataProviders.Matches
{
    public class MatchDto
    {
        public string Id { get; set; }
        public string CompetitionId { get; set; }
        public string SeasonId { get; set; }
        public MatchScoreDto Score { get; set; }
        public MatchStatus Status { get; set; }
        public MatchStage Stage { get; set; }
        public string Group { get; set; }
        public DateTime UtcDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public int? Matchday { get; set; }
        public string HomeTeamId { get; set; }
        public string AwayTeamId { get; set; }
    }
}
