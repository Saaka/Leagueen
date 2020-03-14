using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using System;
using Xunit;
using FluentAssertions;
using Leagueen.Domain.Exceptions;
using System.Collections.Generic;

namespace Leagueen.Tests.Unit.Domain.Entities
{
    [Trait(Traits.Category, Traits.UnitTests)]
    [Trait(Traits.UnitTests, nameof(FriendshipRequestShould))]
    public class FriendshipRequestShould
    {
        [Fact]
        public void HaveValidStateOnCreation()
        {
            var guid = new Guid("E12136F3-F33E-4671-93FA-FD65AF7A5511");
            var requesterId = 1;
            var addresseeId = 2;
            var createDate = new DateTime(2019, 05, 06, 15, 00, 00);

            var request = new FriendshipRequest(guid, requesterId, addresseeId, createDate);
            request.FriendshipRequestGuid.Should().Be(guid);
            request.Status.Should().Be(FriendshipRequestStatus.Pending);
            request.RequesterId.Should().Be(requesterId);
            request.AddresseeId.Should().Be(addresseeId);
            request.CreateDate.Should().Be(createDate);
        }

        [Fact]
        public void HaveAcceptedStatusAfterAccepting()
        {
            var guid = new Guid("E12136F3-F33E-4671-93FA-FD65AF7A5511");
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
            var guid = new Guid("E12136F3-F33E-4671-93FA-FD65AF7A5511");
            var requesterId = 1;
            var addresseeId = 2;
            var createDate = new DateTime(2019, 05, 06, 15, 00, 00);

            var request = new FriendshipRequest(guid, requesterId, addresseeId, createDate)
                .RejectRequest();

            request
                .Status.Should().Be(FriendshipRequestStatus.Rejected);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void ThrowExceptionForInvalidGuid(Guid guid)
        {
            var requesterId = 1;
            var addresseeId = 2;
            var createDate = new DateTime(2019, 05, 06, 15, 00, 00);

            Action creation = () =>
            {
                var request = new FriendshipRequest(guid, requesterId, addresseeId, createDate);
            };

            creation.Should().Throw<DomainException>()
                .Which
                .ExceptionCode.Should().Be(ExceptionCode.FriendshipRequestGuidRequired);
        }

        public static IEnumerable<object[]> CreateDateTestData = new List<object[]>
        {
            new object[] { DateTime.MinValue },
            new object[] { null },
        };

        [Theory]
        [MemberData(nameof(CreateDateTestData))]
        public void ThrowExceptionForInvalidCreateDate(DateTime createDate)
        {
            var guid = new Guid("E12136F3-F33E-4671-93FA-FD65AF7A5511");
            var requesterId = 1;
            var addresseeId = 2;

            Action creation = () =>
            {
                var request = new FriendshipRequest(guid, requesterId, addresseeId, createDate);
            };

            creation.Should().Throw<DomainException>()
                .Which
                .ExceptionCode.Should().Be(ExceptionCode.FriendshipRequestCreateDateRequired);
        }

        [Fact]
        public void ThrowExceptionForInvalidRequesterId()
        {
            var guid = new Guid("E12136F3-F33E-4671-93FA-FD65AF7A5511");
            var requesterId = 0;
            var addresseeId = 2;
            var createDate = new DateTime(2019, 05, 06, 15, 00, 00);

            Action creation = () =>
            {
                var request = new FriendshipRequest(guid, requesterId, addresseeId, createDate);
            };

            creation.Should().Throw<DomainException>()
                .Which
                .ExceptionCode.Should().Be(ExceptionCode.FriendshipRequestRequesterRequired);
        }

        [Fact]
        public void ThrowExceptionForInvalidAddresseeId()
        {
            var guid = new Guid("E12136F3-F33E-4671-93FA-FD65AF7A5511");
            var requesterId = 1;
            var addresseeId = 0;
            var createDate = new DateTime(2019, 05, 06, 15, 00, 00);

            Action creation = () =>
            {
                var request = new FriendshipRequest(guid, requesterId, addresseeId, createDate);
            };

            creation.Should().Throw<DomainException>()
                .Which
                .ExceptionCode.Should().Be(ExceptionCode.FriendshipRequestAddresseeRequired);
        }
    }
}
