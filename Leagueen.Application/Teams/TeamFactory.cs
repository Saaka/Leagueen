using Leagueen.Application.DataProviders.Competitions;
using Leagueen.Domain.Entities;

namespace Leagueen.Application.Teams
{
    public interface ITeamFactory
    {
        Team CreateTeam(TeamDto teamInfo);
    }

    public class TeamFactory : ITeamFactory
    {
        public Team CreateTeam(TeamDto teamInfo)
        {
            return new Team(teamInfo.Name, GetShortname(teamInfo), GetTla(teamInfo), teamInfo.CrestUrl, teamInfo.Website);
        }

        private string GetShortname(TeamDto ti)
        {
            return ti.ShortName ?? ti.Name;
        }

        private string GetTla(TeamDto ti)
        {
            return ti.Tla ?? GetShortname(ti)
                .Replace(" ", "")
                .Substring(0, 3)
                .ToUpper();
        }
    }
}
