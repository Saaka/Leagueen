using Leagueen.Domain.Enums;
using Leagueen.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leagueen.Domain.Entities
{
    public class Group
    {
        public int GroupId { get; private set; }
        public Guid GroupGuid { get; private set; }
        public int OwnerId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime? LastUpdate { get; private set; }
        public GroupStatus Status { get; private set; }

        public virtual IReadOnlyCollection<GroupMember> GroupMembers => _groupMembers.AsReadOnly();
        protected List<GroupMember> _groupMembers = new List<GroupMember>();

        public virtual GroupSettings GroupSettings { get; private set; }

        private Group() { }
        public Group(Guid groupGuid, int ownerId, 
            string name, string description)
        {
            GroupGuid = groupGuid;
            OwnerId = ownerId;
            Name = name;
            Description = description;
            Status = GroupStatus.Active;

            ValidateCreation();
        }

        public Group AddSettings(GroupSettings settings)
        {
            if (GroupSettings != null)
                throw new DomainException(ExceptionCode.GroupAlreadyHasSettings);

            GroupSettings = settings;
            return this;
        }

        public Group AddMember(GroupMember member)
        {
            if (GroupMembers.Any(x => x.UserId == member.UserId && x.IsActive))
                throw new DomainException(ExceptionCode.GroupMemberAlreadyExists);

            _groupMembers.Add(member);
            return this;
        }

        public Group MarkUpdate(DateTime timestamp)
        {
            LastUpdate = timestamp;
            return this;
        }

        public Group Archive()
        {
            if (Status == GroupStatus.Deactivated)
                throw new DomainException(ExceptionCode.CantArchiveDeactivatedGroup);

            Status = GroupStatus.Archived;
            return this;
        }

        public Group Deactivate()
        {
            Status = GroupStatus.Deactivated;
            return this;
        }

        private void ValidateCreation()
        {
            if (GroupGuid.Equals(Guid.Empty))
                throw new DomainException(ExceptionCode.GroupGuidRequired);
            if (OwnerId == 0)
                throw new DomainException(ExceptionCode.GroupOwnerRequired);
            if (string.IsNullOrWhiteSpace(Name))
                throw new DomainException(ExceptionCode.GroupNameRequired);
        }
    }
}
