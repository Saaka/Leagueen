using Leagueen.Domain.Enums;
using Leagueen.Domain.Exceptions;
using System;

namespace Leagueen.Domain.Entities
{
    public class Match
    {
        public int MatchId { get; private set; }
        public int ExternalId { get; private set; }
        public int SeasonId { get; private set; }
        public DateTime Date { get; private set; }
        public MatchStatus Status { get; private set; }
        public MatchStage Stage { get; private set; }
        public MatchResult Result { get; private set; }
        public string Group { get; private set; }
        public int? Matchday { get; private set; }
        public int HomeTeamId { get; private set; }
        public int AwayTeamId { get; private set; }
        public DateTime LastProviderUpdate { get; private set; }

        public virtual Season Season { get; private set; }
        public virtual Team HomeTeam { get; private set; }
        public virtual Team AwayTeam { get; private set; }
        public virtual MatchScore MatchScore { get; private set; }

        private Match() { }

        public Match(int externalId, Season season,
            Team homeTeam, Team awayTeam, DateTime date,
            MatchStatus status, MatchStage stage, DateTime lastProviderUpdate,
            string group = null, int? matchday = null)
        {
            ExternalId = externalId;
            Season = season;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            Date = date;
            Status = status;
            Stage = stage;
            Group = group;
            Matchday = matchday;
            LastProviderUpdate = lastProviderUpdate;
            Result = MatchResult.Unknown;

            ValidateCreation();
        }

        public Match SetResult(MatchResult result)
        {
            Result = result;
            return this;
        }

        public Match AddScore(MatchScore score)
        {
            if (MatchScore != null)
                throw new DomainException(ExceptionCode.MatchAlreadyHasScore);

            Result = score.Result;
            MatchScore = score;
            return this;
        }

        public Match UpdateDate(DateTime date)
        {
            Date = date;
            return this;
        }

        public Match SetStatus(MatchStatus status)
        {
            Status = status;
            return this;
        }

        public Match SetProviderUpdate(DateTime date)
        {
            LastProviderUpdate = date;
            return this;
        }

        private void ValidateCreation()
        {
            if (ExternalId == 0)
                throw new DomainException(ExceptionCode.MatchExternalIdRequred);
            if (Season == null)
                throw new DomainException(ExceptionCode.MatchSeasonRequired);
            if (!Enum.IsDefined(typeof(MatchStatus), Status))
                throw new DomainException(ExceptionCode.MatchStatusRequired);
            if (!Enum.IsDefined(typeof(MatchStage), Stage))
                throw new DomainException(ExceptionCode.MatchStageRequired);
            if (HomeTeam == null)
                throw new DomainException(ExceptionCode.MatchHomeTeamRequired);
            if (AwayTeam == null)
                throw new DomainException(ExceptionCode.MatchAwayTeamRequired);
            if (Date == null)
                throw new DomainException(ExceptionCode.MatchDateRequired);
            if (LastProviderUpdate == null)
                throw new DomainException(ExceptionCode.MatchProviderUpdateRequired);
        }
    }
}
