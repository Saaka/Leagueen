using System;

namespace Leagueen.Application.Groups.Queries.Models
{
    public class UserGroupInfo
    {
        public Guid GroupGuid { get; set; }
        public bool IsAdmin { get; set; }
        public string Name { get; set; }
        public bool IsPrivate { get; set; }
    }
}
