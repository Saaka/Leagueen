using Leagueen.Domain.Enums;
using Leagueen.Domain.Exceptions;
using System;

namespace Leagueen.Domain.Entities
{
    public class FriendshipRequest
    {
        public int FriendshipRequestId { get; private set; }
        public string Guid { get; private set; }
        public int RequesterId { get; private set; }
        public int AddresseeId { get; private set; }
        public DateTime CreateDate { get; private set; }
        public FriendshipRequestStatus Status { get; private set; }

        private FriendshipRequest() { }
        public FriendshipRequest(string guid, int requesterId, int addresseeId, DateTime createDate)
        {
            Guid = guid;
            RequesterId = requesterId;
            AddresseeId = addresseeId;
            CreateDate = createDate;
            Status = FriendshipRequestStatus.Pending;

            ValidateCreation();
        }

        private void ValidateCreation()
        {
            if (string.IsNullOrWhiteSpace(Guid))
                throw new DomainException(ExceptionCode.FriendshipRequestGuidRequired);
            if (RequesterId == 0)
                throw new DomainException(ExceptionCode.FriendshipRequestRequesterRequired);
            if (AddresseeId == 0)
                throw new DomainException(ExceptionCode.FriendshipRequestAddresseeRequired);
            if (CreateDate == null || CreateDate == DateTime.MinValue)
                throw new DomainException(ExceptionCode.FriendshipRequestCreateDateRequired);
        }

        public FriendshipRequest AcceptRequest()
        {
            if (Status == FriendshipRequestStatus.Rejected)
                throw new DomainException(ExceptionCode.FriendshipRequestAlreadyRejected);

            Status = FriendshipRequestStatus.Accepted;
            return this;
        }

        public FriendshipRequest RejectRequest()
        {
            if (Status == FriendshipRequestStatus.Accepted)
                throw new DomainException(ExceptionCode.FriendshipRequestAlreadyAccepted);

            Status = FriendshipRequestStatus.Rejected;
            return this;
        }
    }
}
