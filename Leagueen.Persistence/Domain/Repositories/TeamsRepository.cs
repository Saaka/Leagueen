using Leagueen.Application.Competitions.Repositories;
using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace Leagueen.Persistence.Domain.Repositories
{
    public class TeamsRepository : ITeamsRepository
    {
        private readonly AppDbContext context;

        public TeamsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Team> GetTeamByExternalId(string externalId, DataProviderType providerType)
        {
            var query = TeamByExternalIdQuery(externalId, providerType);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Team> SaveTeam(Team team)
        {
            context.Attach(team);
            await context.SaveChangesAsync();
            return team;
        }

        public async Task<bool> TeamExistsForExternalId(string externalId, DataProviderType providerType)
        {
            var query = TeamByExternalIdQuery(externalId, providerType);
            return await query.AnyAsync();
        }

        private IQueryable<Team> TeamByExternalIdQuery(string externalId, DataProviderType providerType)
        {
            return from t in context.Teams
                   join tm in context.TeamExternalMappings on t.TeamId equals tm.TeamId
                   where tm.ProviderType == providerType && tm.ExternalId == externalId
                   select t;
        }
    }
}
