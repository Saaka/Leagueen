using Leagueen.Application.DataProviders.Matches;
using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using System.Linq;

namespace Leagueen.Application.Matches
{
    public interface IMatchFactory
    {
        Match CreateMatch(Season season, MatchDto info);
    }

    public class MatchFactory : IMatchFactory
    {
        private readonly IScoreFactory scoreFactory;

        public MatchFactory(
            IScoreFactory scoreFactory)
        {
            this.scoreFactory = scoreFactory;
        }

        public Match CreateMatch(Season season, MatchDto info)
        {
            var homeTeam = season.Teams.FirstOrDefault(x => x.Team?.ExternalId == info.HomeTeamId);
            var awayTeam = season.Teams.FirstOrDefault(x => x.Team?.ExternalId == info.AwayTeamId);
            var match = new Match(info.Id, season, homeTeam.Team, awayTeam.Team,
                info.UtcDate, info.Status, info.Stage, info.LastUpdated, info.Group, info.Matchday);

            if (info.Score.Result != MatchResult.Unknown)
                scoreFactory.CreateScore(match, info.Score);

            return match;
        }
    }
}
