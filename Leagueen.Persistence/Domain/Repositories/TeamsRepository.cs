using Leagueen.Application.Competitions.Repositories;
using Leagueen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Leagueen.Persistence.Domain.Repositories
{
    public class TeamsRepository : ITeamsRepository
    {
        private readonly AppDbContext context;

        public TeamsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Team> GetTeamByExternalId(string externalId)
        {
            return await context.Teams.FirstOrDefaultAsync(x => x.ExternalId == externalId);
        }

        public async Task<bool> TeamExistsForExternalId(string externalId)
        {
            return await context.Teams.AnyAsync(x => x.ExternalId == externalId);
        }

        public async Task<Team> SaveTeam(Team team)
        {
            context.Attach(team);
            await context.SaveChangesAsync();
            return team;
        }
    }
}
