using Leagueen.Application.DataProviders.Matches;
using Leagueen.Domain.Entities;

namespace Leagueen.Application.Matches
{
    public interface IScoreUpdater
    {
        void UpdateScore(MatchScore matchScore, MatchScoreDto info);
    }

    public class ScoreUpdater : IScoreUpdater
    {
        public void UpdateScore(MatchScore matchScore, MatchScoreDto info)
        {
            matchScore.UpdateScore(info.Result, info.Duration,
                info.FullTime?.HomeTeam, info.FullTime?.AwayTeam, info.HalfTime?.HomeTeam, info.HalfTime.AwayTeam,
                info.ExtraTime?.HomeTeam, info.ExtraTime?.AwayTeam, info.Penalties?.HomeTeam, info.Penalties?.AwayTeam);
        }
    }
}
