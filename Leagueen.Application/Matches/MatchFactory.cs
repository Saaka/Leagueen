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
            var homeTeam = season.Teams
                .FirstOrDefault(x => x.Team.ExternalMappings
                                        .Any(m => m.ExternalId == info.HomeTeamId.ToString() && m.ProviderType == season.Competition.DataProvider.Type));
            var awayTeam = season.Teams
                .FirstOrDefault(x => x.Team.ExternalMappings
                                        .Any(m => m.ExternalId == info.AwayTeamId.ToString() && m.ProviderType == season.Competition.DataProvider.Type));

            var match = new Match(info.Id, season, homeTeam.Team, awayTeam.Team,
                info.UtcDate, info.Status, info.Stage, info.LastUpdated, info.Group, info.Matchday);

            if (info.Score.Result != MatchResult.Unknown)
            {
                var score = scoreFactory.CreateScore(match, info.Score);
                match.AddScore(score);
            }

            return match;
        }
    }
}
