namespace Leagueen.Domain.Enums
{
    public enum ExceptionCode
    {
        InvalidGoogleToken = 1,
        UserNotFound,
        UserEmailNotUnique,
        InvalidCompetitionName,
        InvalidCompetitionCode,
        InvalidCompetitionExternalId,
        InvalidCompetitionType,
        InvalidCompetitionModel,
        SeasonCompetitionRequried,
        SeasonExternalIdRequired,
        SeasonStartDateRequired,
        SeasonEndDateRequired,
        SeasonCurrentMatchdayRequired,
        TeamNameRequired,
        TeamShortNameRequired,
        TeamTlaRequired,
        TeamIdRequired,
        SeasonIdRequired,
    }
}
