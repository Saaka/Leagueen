using Leagueen.Application.DataProviders.Matches;
using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;

namespace Leagueen.Application.Matches
{
    public interface IMatchUpdater
    {
        bool UpdateMatch(Match match, MatchDto info);
    }
    public class MatchUpdater : IMatchUpdater
    {
        private readonly IScoreFactory scoreFactory;
        private readonly IScoreUpdater scoreUpdater;

        public MatchUpdater(
            IScoreFactory scoreFactory,
            IScoreUpdater scoreUpdater)
        {
            this.scoreFactory = scoreFactory;
            this.scoreUpdater = scoreUpdater;
        }

        public bool UpdateMatch(Match match, MatchDto info)
        {
            if (match.LastProviderUpdate == info.LastUpdated)
                return false;

            if (info.Score.Result != MatchResult.Unknown)
            {
                if (match.MatchScore != null)
                    scoreUpdater.UpdateScore(match.MatchScore, info.Score);
                else
                {
                    var score = scoreFactory.CreateScore(match, info.Score);
                    match.AddScore(score);
                }
            }
            match
            .SetStatus(info.Status)
            .UpdateDate(info.UtcDate)
            .SetProviderUpdate(info.LastUpdated);

            return true;
        }
    }
}
