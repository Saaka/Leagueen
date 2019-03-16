using Leagueen.Application.DataProviders.Matches;
using Leagueen.Common;
using Leagueen.Domain.Entities;

namespace Leagueen.Application.Matches
{
    public interface IScoreFactory
    {
        MatchScore CreateScore(Match match, MatchScoreDto info);
    }

    public class ScoreFactory : IScoreFactory
    {
        private readonly IGuid guid;

        public ScoreFactory(IGuid guid)
        {
            this.guid = guid;
        }
        public MatchScore CreateScore(Match match, MatchScoreDto info)
        {
            return new MatchScore(guid.GetGuid(), match, info.Result, info.Duration,
                info.FullTime?.HomeTeam, info.FullTime?.AwayTeam, info.HalfTime?.HomeTeam, info.HalfTime.AwayTeam,
                info.ExtraTime?.HomeTeam, info.ExtraTime?.AwayTeam, info.Penalties?.HomeTeam, info.Penalties?.AwayTeam);
        }
    }
}
