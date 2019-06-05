using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using System;
using Xunit;
using FluentAssertions;

namespace Leagueen.Tests.Unit.Domain.Entities
{
    [Trait(Traits.Category, Traits.UnitTests)]
    [Trait(Traits.UnitTests, nameof(FriendshipRequestShould))]
    public class FriendshipRequestShould
    {
        [Fact]
        public void HaveValidStateOnCreation()
        {
            var guid = "12345";
            var requesterId = 1;
            var addresseeId = 2;
            var createDate = new DateTime(2019, 05, 06, 15, 00, 00);

            var request = new FriendshipRequest(guid, requesterId, addresseeId, createDate);
            request.Guid.Should().Be(guid);
            request.Status.Should().Be(FriendshipRequestStatus.Pending);
            request.RequesterId.Should().Be(requesterId);
            request.AddresseeId.Should().Be(addresseeId);
            request.CreateDate.Should().Be(createDate);
        }

        [Fact]
        public void HaveAcceptedStatusAfterAccepting()
        {
            var guid = "12345";
            var requesterId = 1;
            var addresseeId = 2;
            var createDate = new DateTime(2019, 05, 06, 15, 00, 00);

            var request = new FriendshipRequest(guid, requesterId, addresseeId, createDate)
                .AcceptRequest();

            request
                .Status.Should().Be(FriendshipRequestStatus.Accepted);
        }

        [Fact]
        public void HaveRejectedStatusAfterRejecting()
        {
            var guid = "12345";
            var requesterId = 1;
            var addresseeId = 2;
            var createDate = new DateTime(2019, 05, 06, 15, 00, 00);

            var request = new FriendshipRequest(guid, requesterId, addresseeId, createDate)
                .RejectRequest();

            request
                .Status.Should().Be(FriendshipRequestStatus.Rejected);
        }
    }
}
