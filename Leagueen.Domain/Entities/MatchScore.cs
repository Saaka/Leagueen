using System;
using Leagueen.Domain.Enums;
using Leagueen.Domain.Exceptions;

namespace Leagueen.Domain.Entities
{
    public class MatchScore
    {
        public int MatchScoreId { get; private set; }
        public int MatchId { get; private set; }
        public MatchResult Result { get; private set; }
        public MatchDuration Duration { get; private set; }
        public int? FullTimeHome { get; private set; }
        public int? FullTimeAway { get; private set; }
        public int? HalfTimeHome { get; private set; }
        public int? HalfTimeAway { get; private set; }
        public int? ExtraTimeHome { get; private set; }
        public int? ExtraTimeAway { get; private set; }
        public int? PentaltiesHome { get; private set; }
        public int? PentaltiesAway { get; private set; }

        public virtual Match Match { get; private set; }

        public MatchScore(Match match,
            MatchResult result, MatchDuration duration,
            int? fullTimeHome = null, int? fullTimeAway = null,
            int? halfTimeHome = null, int? halfTimeAway = null,
            int? extraTimeHome = null, int? extraTimeAway = null,
            int? pentaltiesHome = null, int? pentaltiesAway = null)
        {
            Match = match;
            Result = result;
            Duration = duration;
            FullTimeHome = fullTimeHome;
            FullTimeAway = fullTimeAway;
            HalfTimeHome = halfTimeHome;
            HalfTimeAway = halfTimeAway;
            ExtraTimeHome = extraTimeHome;
            ExtraTimeAway = extraTimeAway;
            PentaltiesHome = pentaltiesHome;
            PentaltiesAway = pentaltiesAway;

            ValidateCreation();
        }

        public MatchScore UpdateRegularScore(
            MatchResult result,
            int fullTimeHome, int fullTimeAway,
            int? halfTimeHome = null, int? halfTimeAway = null)
        {
            Result = result;
            FullTimeHome = fullTimeHome;
            FullTimeAway = fullTimeAway;
            HalfTimeHome = halfTimeHome;
            HalfTimeAway = halfTimeAway;
            Duration = MatchDuration.Regular;
            return this;
        }

        public MatchScore UpdateExtraTimeScore(
            MatchResult result,
            int fullTimeHome, int fullTimeAway,
            int? halfTimeHome = null, int? halfTimeAway = null,
            int? extraTimeHome = null, int? extraTimeAway = null)
        {
            Result = result;
            FullTimeHome = fullTimeHome;
            FullTimeAway = fullTimeAway;
            HalfTimeHome = halfTimeHome;
            HalfTimeAway = halfTimeAway;
            ExtraTimeHome = extraTimeHome;
            ExtraTimeAway = extraTimeAway;
            Duration = MatchDuration.ExtraTime;
            return this;
        }

        public MatchScore UpdatePenaltiesScore(
            MatchResult result,
            int fullTimeHome, int fullTimeAway,
            int? halfTimeHome = null, int? halfTimeAway = null,
            int? extraTimeHome = null, int? extraTimeAway = null,
            int? pentaltiesHome = null, int? pentaltiesAway = null)
        {
            Result = result;
            FullTimeHome = fullTimeHome;
            FullTimeAway = fullTimeAway;
            HalfTimeHome = halfTimeHome;
            HalfTimeAway = halfTimeAway;
            ExtraTimeHome = extraTimeHome;
            ExtraTimeAway = extraTimeAway;
            PentaltiesHome = pentaltiesHome;
            PentaltiesAway = pentaltiesAway;
            Duration = MatchDuration.PenaltyShootout;
            return this;
        }

        private void ValidateCreation()
        {
            if (Match == null)
                throw new DomainException(ExceptionCode.MatchScoreMatchRequired);
            if (!Enum.IsDefined(typeof(MatchResult), Result))
                throw new DomainException(ExceptionCode.MatchScoreResultRequired);
            if (!Enum.IsDefined(typeof(MatchDuration), Duration))
                throw new DomainException(ExceptionCode.MatchScoreDurationRequired);
        }
    }
}
