using Leagueen.Application.Groups.Queries.Models;
using Leagueen.Application.Groups.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Leagueen.Persistence.Domain.Repositories
{
    public class UserGroupsRepository : IUserGroupsRepository
    {
        private readonly AppDbContext context;

        public UserGroupsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<UserGroupInfo>> GetUserGroups(int userId)
        {
            var query = from ug in context.Groups
                        join gm in context.GroupMembers on ug.GroupId equals gm.GroupId

                        where gm.UserId == userId && gm.IsActive
                                && ug.Status == Leagueen.Domain.Enums.GroupStatus.Active
                        select new UserGroupInfo
                        {
                            GroupGuid = ug.GroupGuid,
                            Name = ug.Name,
                            IsAdmin = ug.OwnerId == userId
                        };

            return await query.ToListAsync();
        }
    }
}
