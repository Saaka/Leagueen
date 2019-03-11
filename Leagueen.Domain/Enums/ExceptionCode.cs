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
    }
}
