using Leagueen.Application.Friends.Repositories;
using Leagueen.Domain.Entities;
using System.Threading.Tasks;

namespace Leagueen.Persistence.Domain.Repositories
{
    public class FriendshipAggregateRepository : IFriendshipAggregateRepository
    {
        private readonly AppDbContext context;

        public FriendshipAggregateRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task SaveFriendshipRequest(FriendshipRequest request)
        {
            context.Attach(request);
            await context.SaveChangesAsync();
        }
    }
}
