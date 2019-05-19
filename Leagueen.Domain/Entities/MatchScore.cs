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

        private MatchScore() { }
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

        public MatchScore UpdateScore(
            MatchResult result, MatchDuration duration,
            int? fullTimeHome, int? fullTimeAway,
            int? halfTimeHome = null, int? halfTimeAway = null,
            int? extraTimeHome = null, int? extraTimeAway = null,
            int? pentaltiesHome = null, int? pentaltiesAway = null)
        {
            Result = result;
            Match.SetResult(Result);

            FullTimeHome = fullTimeHome;
            FullTimeAway = fullTimeAway;
            HalfTimeHome = halfTimeHome;
            HalfTimeAway = halfTimeAway;
            ExtraTimeHome = extraTimeHome;
            ExtraTimeAway = extraTimeAway;
            PentaltiesHome = pentaltiesHome;
            PentaltiesAway = pentaltiesAway;
            Duration = duration;
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
