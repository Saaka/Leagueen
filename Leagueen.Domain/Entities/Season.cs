using Leagueen.Domain.Enums;
using Leagueen.Domain.Exceptions;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Leagueen.Domain.Entities
{
    public class Season
    {
        public int SeasonId { get; private set; }
        public int CompetitionId { get; private set; }
        public int ExternalId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public int CurrentMatchday { get; private set; }
        public bool IsActive { get; private set; }
        public int? WinnerId { get; private set; }

        public virtual IReadOnlyCollection<TeamSeason> Teams => _teams.AsReadOnly();
        protected List<TeamSeason> _teams = new List<TeamSeason>();

        public virtual IReadOnlyCollection<Match> Matches => _matches.AsReadOnly();
        protected List<Match> _matches = new List<Match>();

        public virtual Competition Competition { get; private set; }
        public virtual Team Winner { get; private set; }

        private Season() { }

        public Season(Competition competition, int externalId, DateTime startDate, DateTime endDate, int currentMatchday)
        {
            Competition = competition;
            ExternalId = externalId;
            StartDate = startDate;
            EndDate = endDate;
            CurrentMatchday = currentMatchday;

            competition.AddSeason(this);
            ValidateCreation();
        }

        public Season SetActive()
        {
            IsActive = true;
            return this;
        }

        public Season Deactivate()
        {
            IsActive = false;
            return this;
        }

        public Season SetMatchday(int currentMatchday)
        {
            CurrentMatchday = currentMatchday;
            return this;
        }

        public Season AddTeam(Team team)
        {
            _teams.Add(new TeamSeason(team, this));
            return this;
        }

        public Season AddMatch(Match match)
        {
            if (Matches.Any(x => x.ExternalId == match.ExternalId))
                throw new DomainException(ExceptionCode.SeasonAlreadyContainsMatch);

            _matches.Add(match);
            return this;
        }

        public Season SetWinner(Team team)
        {
            Winner = team;
            return this;
        }

        private void ValidateCreation()
        {
            if (Competition == null)
                throw new DomainException(ExceptionCode.SeasonCompetitionRequried);
            if (ExternalId == 0)
                throw new DomainException(ExceptionCode.SeasonExternalIdRequired);
            if (StartDate == null)
                throw new DomainException(ExceptionCode.SeasonStartDateRequired);
            if (EndDate == null)
                throw new DomainException(ExceptionCode.SeasonEndDateRequired);
            if (CurrentMatchday == 0)
                throw new DomainException(ExceptionCode.SeasonCurrentMatchdayRequired);
        }
    }
}
