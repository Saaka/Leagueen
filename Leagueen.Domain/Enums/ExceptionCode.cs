﻿namespace Leagueen.Domain.Enums
{
    public enum ExceptionCode
    {
        InvalidGoogleToken = 1,
        UserNotFound,
        UserEmailNotUnique,
        CompetitionNameRequired,
        CompetitionCodeRequired,
        CompetitionExternalIdRequired,
        CompetitionTypeInvalid,
        CompetitionModelInvalid,
        SeasonCompetitionRequried,
        SeasonExternalIdRequired,
        SeasonStartDateRequired,
        SeasonEndDateRequired,
        SeasonCurrentMatchdayRequired,
        SeasonIdRequired,
        TeamNameRequired,
        TeamShortNameRequired,
        TeamTlaRequired,
        TeamIdRequired,
        TeamExternalIdRequired,
        SeasonRequired,
        TeamRequired,
        TeamAlreadyInSeason,
        SeasonAlreadyInCompetition,
        MatchAlreadyHasScore,
        MatchExternalIdRequred,
        MatchSeasonRequired,
        MatchHomeTeamRequired,
        MatchAwayTeamRequired,
        MatchDateRequired,
        MatchStatusRequired,
        MatchStageRequired,
        MatchScoreMatchRequired,
        MatchScoreResultRequired,
        MatchScoreDurationRequired,
        MatchProviderUpdateRequired,
        SeasonAlreadyContainsMatch,
        ActiveCompetitionNotFound,
        ActiveSeasonNotFoundForCompetition,
        DataProviderTypeInvalid,
        DataProviderNameRequired,
        DataProviderAlreadyConatinsCompetition,
        UpdateLogTypeRequred,
        UpdateLogDateRequred,
        UpdateLogProviderTypeRequred,
        UpdateLogCompetitionRequiredForLogType,
        UpdateLogCompetitionInvalidForLogType,
        UserDisplayNameNotUnique,
        ProviderMappingAlreadyExists,
        InvalidFacebookToken,
        FacebookTokenEmailPermissionRequired,
        GroupTypeInvalid,
        GroupVisibilityInvalid,
        GroupOwnerRequired,
        GroupNameRequired,
        GroupAlreadyHasSettings,
        GroupMemberAlreadyExists,
        GroupMemberUserIdRequired,
        GroupMemberGroupRequired,
        CantAddNegativePoints,
        CantArchiveDeactivatedGroup,
        GroupSettingsGroupRequired,
        GroupSettingsPointsForExactScoreRequired,
        GroupSettingsPointsForResultRequired,
        GroupSettingsMatchResultResolveModeInvalid,
        CantSetCompetitionForThisTypeOfGroup,
        InvalidCompetitionData
    }
}
