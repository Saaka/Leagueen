using System;
using Leagueen.Domain.Enums;
using Leagueen.Domain.Exceptions;

namespace Leagueen.Domain.Entities
{
    public class GroupSettings
    {
        public int GroupSettingsId { get; private set; }
        public int GroupId { get; private set; }
        public GroupType Type { get; private set; }
        public GroupVisibility Visibility { get; private set; }
        public int PointsForExactScore { get; private set; }
        public int PointsForResult { get; private set; }
        public MatchResultResolveMode ResultResolveMode { get; private set; }
        public int? CompetitionId { get; private set; }
        public int? SeasonId { get; private set; }

        public virtual Group Group { get; private set; }

        private GroupSettings() { }
        public GroupSettings(Group group, 
            int pointsForExactScore, int pointsForResult,
            GroupType type, GroupVisibility visibility, MatchResultResolveMode resultResolveMode)
        {
            Group = group;
            Type = type;
            Visibility = visibility;
            PointsForExactScore = pointsForExactScore;
            PointsForResult = pointsForResult;
            ResultResolveMode = resultResolveMode;

            ValidateCreation();
        }

        public GroupSettings SetCompetition(int competitionId, int seasonId)
        {
            if (Type != GroupType.Competition)
                throw new DomainException(ExceptionCode.CantSetCompetitionForThisTypeOfGroup);
            if (competitionId == 0 || seasonId == 0)
                throw new DomainException(ExceptionCode.InvalidCompetitionData);

            CompetitionId = competitionId;
            SeasonId = seasonId;

            return this;
        }

        public GroupSettings UpdatePoints(int pointsForScore, int pointsForResult)
        {
            PointsForExactScore = pointsForScore;
            PointsForResult = pointsForResult;

            return this;
        }

        private void ValidateCreation()
        {
            if (Group == null)
                throw new DomainException(ExceptionCode.GroupSettingsGroupRequired);
            if (PointsForExactScore == 0)
                throw new DomainException(ExceptionCode.GroupSettingsPointsForExactScoreRequired);
            if (PointsForResult == 0)
                throw new DomainException(ExceptionCode.GroupSettingsPointsForResultRequired);
            if (!Enum.IsDefined(typeof(GroupType), Type))
                throw new DomainException(ExceptionCode.GroupTypeInvalid);
            if (!Enum.IsDefined(typeof(GroupVisibility), Visibility))
                throw new DomainException(ExceptionCode.GroupVisibilityInvalid);
            if (!Enum.IsDefined(typeof(MatchResultResolveMode), ResultResolveMode))
                throw new DomainException(ExceptionCode.GroupSettingsMatchResultResolveModeInvalid);
        }
    }
}
