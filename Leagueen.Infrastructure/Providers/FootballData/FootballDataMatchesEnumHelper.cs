using Leagueen.Application.Exceptions;
using Leagueen.Application.Matches;
using Leagueen.Domain.Enums;

namespace Leagueen.Infrastructure.Providers.FootballData
{
    public class FootballDataMatchesEnumHelper : IMatchesEnumHelper
    {
        public MatchStage ConvertStage(string stage)
        {
            switch (stage)
            {
                case "REGULAR_SEASON":
                    return MatchStage.RegularSeason;
                case "FINAL":
                    return MatchStage.Final;
                case "SEMI_FINALS":
                    return MatchStage.SemiFinals;
                case "QUARTER_FINALS":
                    return MatchStage.QuarterFinals;
                case "ROUND_OF_16":
                    return MatchStage.RoundOfSixteen;
                case "GROUP_STAGE":
                    return MatchStage.GroupStage;
                case "PLAY_OFF_ROUND":
                    return MatchStage.PlayOffRound;
                case "3RD_QUALIFYING_ROUND":
                    return MatchStage.ThirdQualifyingRound;
                case "2ND_QUALIFYING_ROUND":
                    return MatchStage.SecondQualifyingRound;
                case "1ST_QUALIFYING_ROUND":
                    return MatchStage.FirstQualifyingRound;
                case "3RD_PLACE":
                    return MatchStage.ThirdPlace;
                default:
                    throw new ProviderCommunicationException($"Invalid MatchStage value: {stage}");
            }
        }

        public MatchStatus ConvertStatusCode(string status)
        {
            switch (status)
            {
                case "SCHEDULED":
                    return MatchStatus.Scheduled;
                case "IN_PLAY":
                    return MatchStatus.InPlay;
                case "PAUSED":
                    return MatchStatus.Paused;
                case "FINISHED":
                    return MatchStatus.Finised;
                case "POSTPONED":
                    return MatchStatus.Postponed;
                case "SUSPENDED":
                    return MatchStatus.Suspended;
                case "CANCELED":
                    return MatchStatus.Canceled;
                default:
                    throw new ProviderCommunicationException($"Invalid MatchStatus value: {status}");
            }
        }
    }
}
