using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using System.Threading.Tasks;

namespace Leagueen.Application.Competitions.Repositories
{
    public interface ITeamsRepository
    {
        Task<bool> TeamExistsForExternalId(string externalId, DataProviderType providerType);
        Task<Team> GetTeamByExternalId(string externalId, DataProviderType providerType);
        Task<Team> SaveTeam(Team team);
    }
}
