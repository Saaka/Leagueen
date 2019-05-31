using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leagueen.Persistence.Domain.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(x => x.GroupId);

            builder
                .HasIndex(x => x.GroupGuid)
                .HasName("IX_GroupGuid")
                .IsUnique();

            builder
                .Property(x => x.GroupGuid)
                .IsRequired()
                .HasMaxLength(64);

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(64);

            builder
                .Property(x => x.Description)
                .IsRequired(false)
                .HasMaxLength(1024);

            builder
                .Property(x => x.OwnerId)
                .IsRequired();

            builder
                .Property(x => x.Status)
                .IsRequired()
                .HasConversion(
                    v => (byte)v,
                    v => (GroupStatus)v);
            builder
                .HasOne(x => x.GroupSettings)
                .WithOne(x => x.Group)
                .HasForeignKey<GroupSettings>(x => x.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.GroupMembers)
                .WithOne(x => x.Group)
                .HasForeignKey(x => x.GroupId);

            builder.Metadata
                .FindNavigation(nameof(Group.GroupMembers))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder
                .Property(x => x.LastUpdate)
                .IsRequired(false)
                .HasDefaultValue(null);
        }
    }
}
