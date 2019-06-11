using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using System.Threading.Tasks;

namespace Leagueen.Application.Friends.Repositories
{
    public interface IFriendshipAggregateRepository
    {
        Task SaveFriendshipRequest(FriendshipRequest request);
    }
}
