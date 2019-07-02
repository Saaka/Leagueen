using System;
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
            if (!string.IsNullOrWhiteSpace(ti.Tla))
                return ti.Tla;

            var tla = ConvertToTla(ti.ShortName);
            if (string.IsNullOrWhiteSpace(tla))
                tla = ConvertToTla(ti.Name);

            if (string.IsNullOrWhiteSpace(tla))
                tla = CreateTlaWithFiller(ti.Name);

            return tla;
        }

        private string ConvertToTla(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return null;

            var trimmed = name.Replace(" ", "");
            if (trimmed.Length < 3)
                return null;

            return trimmed
                .Substring(0, 3)
                .ToUpper();
        }

        private string CreateTlaWithFiller(string name)
        {
            return name.Replace(" ", "").PadRight(3, '_');
        }
    }
}
