using System.Threading.Tasks;

namespace Leagueen.Application.Friends.Repositories
{
    public interface IFriendshipRequestsRepository
    {
        Task<bool> FriendshipRequestExists(int requesterId, int addresseeId);
    }
}
