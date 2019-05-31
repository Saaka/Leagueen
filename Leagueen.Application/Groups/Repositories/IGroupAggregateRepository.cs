using Leagueen.Domain.Entities;
using System.Threading.Tasks;

namespace Leagueen.Application.Groups.Repositories
{
    public interface IGroupAggregateRepository
    {
        Task SaveGroup(Group group);
    }
}
