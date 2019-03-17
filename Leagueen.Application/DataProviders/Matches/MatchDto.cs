using Leagueen.Domain.Enums;
using System;

namespace Leagueen.Application.DataProviders.Matches
{
    public class MatchDto
    {
        public int Id { get; set; }
        public int CompetitionId { get; set; }
        public int SeasonId { get; set; }
        public MatchScoreDto Score { get; set; }
        public MatchStatus Status { get; set; }
        public MatchStage Stage { get; set; }
        public string Group { get; set; }
        public DateTime UtcDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public int? Matchday { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
    }
}
