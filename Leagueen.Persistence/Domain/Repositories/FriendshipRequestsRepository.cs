using Leagueen.Application.Friends.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Leagueen.Persistence.Domain.Repositories
{
    public class FriendshipRequestsRepository : IFriendshipRequestsRepository
    {
        private readonly AppDbContext context;

        public FriendshipRequestsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> FriendshipRequestExists(int requesterId, int addresseeId)
        {
            return await context.FriendshipRequests
                .AnyAsync(x => x.AddresseeId == addresseeId
                            && x.RequesterId == requesterId
                            && x.Status == Leagueen.Domain.Enums.FriendshipRequestStatus.Pending);
        }
    }
}
