using Leagueen.Domain.Enums;
using Leagueen.Domain.Exceptions;

namespace Leagueen.Domain.Entities
{
    public class GroupMember
    {
        public int GroupMemberId { get; private set; }
        public int GroupId { get; private set; }
        public int UserId { get; private set; }
        public int Points { get; private set; }
        public bool IsActive { get; private set; }

        public virtual Group Group { get; private set; }

        private GroupMember() { }
        public GroupMember(int userId)
        {
            UserId = userId;
            IsActive = true;
            Points = 0;

            ValidateCreation();
        }

        public GroupMember Deactivate()
        {
            IsActive = false;
            return this;
        }

        public GroupMember AddPoints(int pointsToAdd)
        {
            if (pointsToAdd < 0)
                throw new DomainException(ExceptionCode.CantAddNegativePoints);
            Points += pointsToAdd;
            return this;
        }

        public GroupMember SetPoints(int points)
        {
            Points = points;
            return this;
        }

        private void ValidateCreation()
        {
            if (UserId == 0)
                throw new DomainException(ExceptionCode.GroupMemberUserIdRequired);
        }
    }
}
