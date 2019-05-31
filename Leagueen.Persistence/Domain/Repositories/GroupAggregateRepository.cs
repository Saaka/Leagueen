using Leagueen.Application.Groups.Repositories;
using Leagueen.Domain.Entities;
using System.Threading.Tasks;

namespace Leagueen.Persistence.Domain.Repositories
{
    public class GroupAggregateRepository : IGroupAggregateRepository
    {
        private readonly AppDbContext context;

        public GroupAggregateRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task SaveGroup(Group group)
        {
            context.Attach(group);
            await context.SaveChangesAsync();
        }
    }
}
