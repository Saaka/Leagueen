using Leagueen.Domain.Entities;
using System.Threading.Tasks;

namespace Leagueen.Application.Competitions.Repositories
{
    public interface ITeamsRepository
    {
        Task<bool> TeamExistsForExternalId(string externalId);
        Task<Team> GetTeamByExternalId(string externalId);
        Task<Team> SaveTeam(Team team);
    }
}
