using Leagueen.Domain.Enums;
using Leagueen.Domain.Exceptions;
using System;

namespace Leagueen.Domain.Entities
{
    public class CompetitionUpdate
    {
        public int CompetitionUpdateId { get; private set; }
        public int CompetitionId { get; private set; }
        public DateTime Date { get; private set; }

        public virtual Competition Competition { get; private set; }

        private CompetitionUpdate() { }
        public CompetitionUpdate(
            Competition competition,
            DateTime date)
        {
            Competition = competition;
            Date = date;

            Competition.AddUpdate(this);
            ValidateCreation();
        }

        private void ValidateCreation()
        {
            if (Competition == null)
                throw new DomainException(ExceptionCode.UpdateCompetitionRequired);
            if (Date == null)
                throw new DomainException(ExceptionCode.CompetitionUpdateDateRequired);
        }
    }
}
