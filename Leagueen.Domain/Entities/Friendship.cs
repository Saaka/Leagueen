using Leagueen.Domain.Exceptions;
using System;

namespace Leagueen.Domain.Entities
{
    public class Friendship
    {
        public int FriendshipId { get; private set; }
        public int UserId { get; private set; }
        public int FriendId { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreateDate { get; private set; }

        private Friendship() { }
        public Friendship(int userId, int friendId, DateTime date)
        {
            UserId = userId;
            FriendId = friendId;
            CreateDate = date;
            IsActive = true;

            ValidateCreation();
        }

        private void ValidateCreation()
        {
            if (UserId == 0)
                throw new DomainException(Enums.ExceptionCode.FriendshipUserIdRequired);
            if (FriendId == 0)
                throw new DomainException(Enums.ExceptionCode.FriendshipFriendIdRequired);
            if (CreateDate == null || CreateDate == DateTime.MinValue)
                throw new DomainException(Enums.ExceptionCode.FriendshipCreateDateRequired);
        }

        public Friendship RemoveFriend()
        {
            IsActive = false;
            return this;
        }
    }
}
