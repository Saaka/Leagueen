using System.Collections.Generic;

namespace Leagueen.Application.Groups.Queries.Models
{
    public class GetUserGroupsResult
    {
        public GetUserGroupsResult()
        {
            UserGroups = new List<UserGroupInfo>();
        }

        public ICollection<UserGroupInfo> UserGroups { get; set; }
    }
}
