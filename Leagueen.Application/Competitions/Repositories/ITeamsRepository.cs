using Leagueen.Domain.Entities;
using System.Threading.Tasks;

namespace Leagueen.Application.Competitions.Repositories
{
    public interface ITeamsRepository
    {
        Task<bool> TeamExistsForExternalId(int externalId);
        Task<Team> GetTeamByExternalId(int externalId);
    }
}
