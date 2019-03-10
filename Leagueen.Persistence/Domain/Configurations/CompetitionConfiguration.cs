using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leagueen.Persistence.Domain.Configurations
{
    public class CompetitionConfiguration : IEntityTypeConfiguration<Competition>
    {
        public void Configure(EntityTypeBuilder<Competition> builder)
        {
            builder
                .HasKey(e => e.CompetitionId);
            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(64);
            builder
                .Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(16);
            builder
                .Property(x => x.Type)
                .IsRequired()
                .HasConversion(
                    v => (byte)v,
                    v => (CompetitionType)v);
            builder
                .Property(x => x.Model)
                .IsRequired()
                .HasConversion(
                    v => (byte)v,
                    v => (CompetitionModel)v);
            builder
                .HasMany(x => x.Seasons)
                .WithOne(x => x.Competition)
                .HasForeignKey(x => x.CompetitionId);

            builder.Metadata
                .FindNavigation(nameof(Competition.Seasons))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder
                .Property(x => x.LastProviderUpdate)
                .IsRequired(false)
                .HasDefaultValue(null);
        }
    }
}
