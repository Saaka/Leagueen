using Leagueen.Application.Exceptions;
using Leagueen.Domain.Enums;
using Leagueen.Infrastructure.Providers.FootballData.ProviderModels;
using System.Collections.Generic;
using System.Linq;

namespace Leagueen.Infrastructure.Providers.FootballData
{
    public static class FootballDataMapperHelper
    {
        public static MatchStage ConvertStage(MatchModel model)
        {
            switch (model.Stage)
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
                case "PRELIMINARY_SEMI_FINALS":
                    return MatchStage.PreliminarySemiFinals;
                case "PRELIMINARY_FINAL":
                    return MatchStage.PreliminaryFinal;
                case "PROMOTION_PLAY_OFFS_SEMI_FINALS":
                    return MatchStage.PromotionPlayOffsSemiFinals;
                case "PROMOTION_PLAY_OFFS_FINAL":
                    return MatchStage.PromotionPlayOffsFinal;
                case "EUROPA_LEAGUE_PLAYOFF_SEMI_FINALS":
                    return MatchStage.EuropaLeaguePlayoffSemiFinals;
                case "EUROPA_LEAGUE_PLAYOFF_FINAL":
                    return MatchStage.EuropaLeaguePlayoffFinal;
                case "RELEGATION_PROMOTION_PLAYOFF":
                    return MatchStage.RelegationPromotionPlayoff;
                default:
                    throw new ProviderCommunicationException($"Invalid MatchStage value: {model.Stage}. MatchId: {model.Id} Date: {model.UtcDate} CompetitionId: {model.Competition?.Id}");
            }
        }

        public static MatchStatus ConvertStatus(MatchModel model)
        {
            switch (model.Status)
            {
                case "FINISHED":
                case "AWARDED":
                    return MatchStatus.Finised;
                case "SCHEDULED":
                    return MatchStatus.Scheduled;
                case "IN_PLAY":
                    return MatchStatus.InPlay;
                case "PAUSED":
                    return MatchStatus.Paused;
                case "POSTPONED":
                    return MatchStatus.Postponed;
                case "SUSPENDED":
                    return MatchStatus.Suspended;
                case "CANCELED":
                    return MatchStatus.Canceled;
                default:
                    throw new ProviderCommunicationException($"Invalid MatchStatus value: {model.Status}");
            }
        }

        public static MatchResult ConvertResult(MatchScoreModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Winner))
                return MatchResult.Unknown;

            switch (model.Winner)
            {
                case "HOME_TEAM":
                    return MatchResult.HomeTeam;
                case "AWAY_TEAM":
                    return MatchResult.AwayTeam;
                case "DRAW":
                    return MatchResult.Draw;
                default:
                    throw new ProviderCommunicationException($"Invalid Matchresult value: {model.Winner}");
            }
        }

        public static MatchDuration ConvertDuration(MatchScoreModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Duration))
                return MatchDuration.Unknown;

            switch (model.Duration)
            {
                case "REGULAR":
                    return MatchDuration.Regular;
                case "EXTRA_TIME":
                    return MatchDuration.ExtraTime;
                case "PENALTY_SHOOTOUT":
                    return MatchDuration.PenaltyShootout;
                default:
                    throw new ProviderCommunicationException($"Invalid MatchDuration value: {model.Duration}");

            }
        }

        public static string ConvertGroup(MatchModel model)
        {
            const string GroupPlaceholder = "GROUP";
            if (string.IsNullOrWhiteSpace(model.Group) || !model.Group.ToUpper().Contains(GroupPlaceholder))
                return null;

            return model.Group.ToUpper().Replace(GroupPlaceholder, string.Empty).Trim();
        }

        public static List<string> ConvertClubColors(TeamModel model)
        {
            if (string.IsNullOrWhiteSpace(model.ClubColors))
                return new List<string>();

            var colorList = model.ClubColors.Split('/');

            return colorList
                .Select(c => c.Trim())
                .ToList();
        }

        public static int? MapOptionalTeamId(TeamSimpleModel winner)
        {
            return winner?.Id;
        }
    }
}
