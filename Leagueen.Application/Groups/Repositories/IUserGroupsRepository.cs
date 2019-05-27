using Leagueen.Application.Groups.Queries.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leagueen.Application.Groups.Repositories
{
    public interface IUserGroupsRepository
    {
        Task<ICollection<UserGroupInfo>> GetUserGroups(int userId);
    }
}
