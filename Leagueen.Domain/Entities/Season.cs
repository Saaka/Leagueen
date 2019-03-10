using Leagueen.Domain.Enums;
using Leagueen.Domain.Exceptions;
using System;

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
        public virtual Competition Competition { get; private set; }

        private Season() { }

        public Season(Competition competition, int externalId, DateTime startDate, DateTime endDate, int currentMatchday)
        {
            Competition = competition;
            ExternalId = externalId;
            StartDate = startDate;
            EndDate = endDate;
            CurrentMatchday = currentMatchday;

            ValidateCreation();
        }

        public void SetActive()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public void SetWinner(int winnerId)
        {
            WinnerId = winnerId;
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
