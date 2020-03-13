using Leagueen.Domain.Entities;
using System.Threading.Tasks;

namespace Leagueen.Application.Users.Repositories
{
    public interface IUserAggregateRepository
    {
        Task SaveUser(User user);
    }
}
