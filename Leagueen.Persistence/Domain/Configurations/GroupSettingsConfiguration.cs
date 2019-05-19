using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leagueen.Persistence.Domain.Configurations
{
    public class GroupSettingsConfiguration : IEntityTypeConfiguration<GroupSettings>
    {
        public void Configure(EntityTypeBuilder<GroupSettings> builder)
        {
            builder.HasKey(x => x.GroupSettingsId);
            builder
                .Property(x => x.GroupId)
                .IsRequired();
            builder
                .Property(x => x.PointsForExactScore)
                .IsRequired();
            builder
                .Property(x => x.PointsForResult)
                .IsRequired();
            builder
                .Property(x => x.ResultResolveMode)
                .IsRequired()
                .HasConversion(
                    v => (byte)v,
                    v => (MatchResultResolveMode)v);
            builder
                .Property(x => x.Type)
                .IsRequired()
                .HasConversion(
                    v => (byte)v,
                    v => (GroupType)v);
            builder
                .Property(x => x.Visibility)
                .IsRequired()
                .HasConversion(
                    v => (byte)v,
                    v => (GroupVisibility)v);

            builder
                .HasOne<Competition>(nameof(GroupSettings.CompetitionId))
                .WithMany()
                .IsRequired(false);
            builder
                .HasOne<Season>(nameof(GroupSettings.SeasonId))
                .WithMany()
                .IsRequired(false);
        }
    }
}
