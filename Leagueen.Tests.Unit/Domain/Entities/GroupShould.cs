using FluentAssertions;
using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using Leagueen.Domain.Exceptions;
using System;
using Xunit;

namespace Leagueen.Tests.Unit.Domain.Entities
{
    [Trait(Traits.Category, Traits.UnitTests)]
    [Trait(Traits.UnitTests, nameof(GroupShould))]
    public class GroupShould
    {
        [Fact]
        public void HaveValidStateAfterCreation()
        {
            var guid = new Guid("E12136F3-F33E-4671-93FA-FD65AF7A5511");
            var ownerId = 1;
            var name = "Test12";
            var desc = "";

            var group = new Group(guid, ownerId, name, desc);

            group.GroupGuid.Should().Be(guid);
            group.Name.Should().Be(name);
            group.OwnerId.Should().Be(ownerId);
            group.Description.Should().Be(desc);
            group.Status.Should().Be(GroupStatus.Active);
            group.LastUpdate.Should().BeNull();
        }

        [Fact]
        public void HaveOneMemberAfterOwnerIsAdded()
        {
            var guid = new Guid("E12136F3-F33E-4671-93FA-FD65AF7A5511");
            var ownerId = 1;
            var name = "Test12";
            var desc = "";

            var groupMember = new GroupMember(ownerId);
            var group = new Group(guid, ownerId, name, desc)
                .AddMember(groupMember);

            group.GroupMembers.Should().HaveCount(1);
        }

        [Fact]
        public void HaveSettingsAfterAddingSettings()
        {
            var guid = new Guid("E12136F3-F33E-4671-93FA-FD65AF7A5511");
            var ownerId = 1;
            var name = "Test12";
            var desc = "";

            var groupSettings = new GroupSettings(1, 1, GroupType.Competition, GroupVisibility.Private, MatchResultResolveMode.FinalScore);
            var group = new Group(guid, ownerId, name, desc)
                .AddSettings(groupSettings);

            group.GroupSettings.Should().NotBeNull();
        }

        [Fact]
        public void HaveValidUpdateDateAfterUpdateMarking()
        {
            var guid = new Guid("E12136F3-F33E-4671-93FA-FD65AF7A5511");
            var ownerId = 1;
            var name = "Test12";
            var desc = "";
            var updateDate = new DateTime(2019, 06, 07, 1, 0, 0);

            var group = new Group(guid, ownerId, name, desc)
                .MarkUpdate(updateDate);

            group.LastUpdate.Should().Be(updateDate);
        }

        [Fact]
        public void HaveValidStatusAfterArchivization()
        {
            var guid = new Guid("E12136F3-F33E-4671-93FA-FD65AF7A5511");
            var ownerId = 1;
            var name = "Test12";
            var desc = "";

            var group = new Group(guid, ownerId, name, desc)
                .Archive();

            group.Status.Should().Be(GroupStatus.Archived);
        }

        [Fact]
        public void HaveValidStatusAfterDeactivation()
        {
            var guid = new Guid("E12136F3-F33E-4671-93FA-FD65AF7A5511");
            var ownerId = 1;
            var name = "Test12";
            var desc = "";

            var group = new Group(guid, ownerId, name, desc)
                .Deactivate();

            group.Status.Should().Be(GroupStatus.Deactivated);
        }

        [Fact]
        public void ThrowWhenAddingSecondSettings()
        {
            var guid = new Guid("E12136F3-F33E-4671-93FA-FD65AF7A5511");
            var ownerId = 1;
            var name = "Test12";
            var desc = "";

            var groupSettings = new GroupSettings(1, 1, GroupType.Competition, GroupVisibility.Private, MatchResultResolveMode.FinalScore);
            var group = new Group(guid, ownerId, name, desc)
                .AddSettings(groupSettings);

            Action addSettings = () =>
            {
                group.AddSettings(groupSettings);
            };

            addSettings.Should().Throw<DomainException>()
                .Which
                .ExceptionCode.Should().Be(ExceptionCode.GroupAlreadyHasSettings);
        }

        [Fact]
        public void ThrowWhenAddingSameUserTwice()
        {
            var guid = new Guid("E12136F3-F33E-4671-93FA-FD65AF7A5511");
            var ownerId = 1;
            var name = "Test12";
            var desc = "";
            
            var groupMember = new GroupMember(ownerId);
            var group = new Group(guid, ownerId, name, desc)
                .AddMember(groupMember);

            group.GroupMembers.Should().HaveCount(1);

            Action addMember = () =>
            {
                group.AddMember(groupMember);
            };

            addMember.Should().Throw<DomainException>()
                .Which
                .ExceptionCode.Should().Be(ExceptionCode.GroupMemberAlreadyExists);
        }

        [Fact]
        public void ThrowWhenArchivingDeactivatedGroup()
        {
            var guid = new Guid("E12136F3-F33E-4671-93FA-FD65AF7A5511");
            var ownerId = 1;
            var name = "Test12";
            var desc = "";

            Action archive = () =>
            {
                var group = new Group(guid, ownerId, name, desc)
                    .Deactivate()
                    .Archive();
            };

            archive.Should().Throw<DomainException>()
                .Which
                .ExceptionCode.Should().Be(ExceptionCode.CantArchiveDeactivatedGroup);
        }
    }
}
