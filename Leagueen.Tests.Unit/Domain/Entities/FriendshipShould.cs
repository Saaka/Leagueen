using FluentAssertions;
using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using Leagueen.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Leagueen.Tests.Unit.Domain.Entities
{
    [Trait(Traits.Category, Traits.UnitTests)]
    [Trait(Traits.UnitTests, nameof(FriendshipShould))]
    public class FriendshipShould
    {
        [Fact]
        public void HaveValidStateOnCreation()
        {
            var userId = 1;
            var friendId = 2;
            var createDate = new DateTime(2019, 06, 05, 20, 0, 0);

            var friendship = new Friendship(userId, friendId, createDate);

            friendship.UserId.Should().Be(userId);
            friendship.FriendId.Should().Be(friendId);
            friendship.CreateDate.Should().Be(createDate);
            friendship.IsActive.Should().BeTrue();
        }

        [Fact]
        public void ShouldBeInactiveAfterFriendIsRemoved()
        {
            var userId = 1;
            var friendId = 2;
            var createDate = new DateTime(2019, 06, 05, 20, 0, 0);

            var friendship = new Friendship(userId, friendId, createDate)
                .RemoveFriend();

            friendship.IsActive.Should().BeFalse();
        }

        [Fact]
        public void ShouldThrowExceptionForInvalidUserId()
        {
            var userId = 0;
            var friendId = 2;
            var createDate = new DateTime(2019, 06, 05, 20, 0, 0);

            Action creation = () =>
            {
                var friendship = new Friendship(userId, friendId, createDate);
            };

            creation.Should().Throw<DomainException>()
                .Which
                .ExceptionCode.Should().Be(ExceptionCode.FriendshipUserIdRequired);
        }

        [Fact]
        public void ShouldThrowExceptionForInvalidFriendId()
        {
            var userId = 1;
            var friendId = 0;
            var createDate = new DateTime(2019, 06, 05, 20, 0, 0);

            Action creation = () =>
            {
                var friendship = new Friendship(userId, friendId, createDate);
            };

            creation.Should().Throw<DomainException>()
                .Which
                .ExceptionCode.Should().Be(ExceptionCode.FriendshipFriendIdRequired);
        }

        [Fact]
        public void ShouldThrowExceptionForInvalidCreateDate()
        {
            var userId = 1;
            var friendId = 2;
            var createDate = DateTime.MinValue;

            Action creation = () =>
            {
                var friendship = new Friendship(userId, friendId, createDate);
            };

            creation.Should().Throw<DomainException>()
                .Which
                .ExceptionCode.Should().Be(ExceptionCode.FriendshipCreateDateRequired);
        }
    }
}
