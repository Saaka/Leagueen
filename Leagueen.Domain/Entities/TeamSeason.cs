using Leagueen.Domain.Enums;
using Leagueen.Domain.Exceptions;

namespace Leagueen.Domain.Entities
{
    public class TeamSeason
    {
        public int TeamId { get; set; }
        public int SeasonId { get; set; }

        public virtual Team Team { get; private set; }
        public virtual Season Season { get; private set; }

        private TeamSeason() { }

        public TeamSeason(Team team, Season season)
        {
            Team = team;
            Season = season;

            ValidateRelationCreation();
        }

        private void ValidateRelationCreation()
        {
            if (Team == null)
                throw new DomainException(ExceptionCode.TeamRequired);
            if (Season == null)
                throw new DomainException(ExceptionCode.SeasonRequired);
        }
    }
}
