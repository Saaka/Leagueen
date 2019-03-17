using Leagueen.Domain.Enums;
using System;

namespace Leagueen.Application.Matches.Queries.Models
{
    public class MatchModel
    {
        public int MatchId { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public DateTime Date { get; set; }
        public MatchResult Result { get; set; }
        public MatchStatus Status { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public int CompetitionId { get; set; }
    }
}
