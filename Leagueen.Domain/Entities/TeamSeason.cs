using Leagueen.Domain.Enums;
using Leagueen.Domain.Exceptions;

namespace Leagueen.Domain.Entities
{
    public class TeamSeason
    {
        public int TeamId { get; set; }
        public int SeasonId { get; set; }

        private TeamSeason() { }

        public TeamSeason(int teamId, int seasonId)
        {
            TeamId = teamId;
            SeasonId = seasonId;

            ValidateCreation();
        }

        private void ValidateCreation()
        {
            if (TeamId == 0)
                throw new DomainException(ExceptionCode.TeamIdRequired);
            if (SeasonId == 0)
                throw new DomainException(ExceptionCode.SeasonIdRequired);
        }
    }
}
