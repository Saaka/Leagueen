using Leagueen.Domain.Enums;

namespace Leagueen.Application.DataProviders.Matches
{
    public class MatchScoreDto
    {
        public MatchResult Winner { get; set; }
        public MatchDuration Duration { get; set; }
        public ScoreValueDto FullTime { get; set; }
        public ScoreValueDto HalfTime { get; set; }
        public ScoreValueDto ExtraTime { get; set; }
        public ScoreValueDto Penalties { get; set; }
    }
}
