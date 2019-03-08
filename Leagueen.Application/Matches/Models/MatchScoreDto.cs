namespace Leagueen.Application.Matches.Models
{
    public class MatchScoreDto
    {
        public string Winner { get; set; }
        public string Duration { get; set; }
        public MatchScoreValueDto FullTime { get; set; }
        public MatchScoreValueDto HalfTime { get; set; }
        public MatchScoreValueDto ExtraTime { get; set; }
        public MatchScoreValueDto Penalties { get; set; }
    }
}
