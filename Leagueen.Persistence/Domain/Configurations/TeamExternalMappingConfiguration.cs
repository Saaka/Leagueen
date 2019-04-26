using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leagueen.Persistence.Domain.Configurations
{
    public class TeamExternalMappingConfiguration : IEntityTypeConfiguration<TeamExternalMapping>
    {
        public void Configure(EntityTypeBuilder<TeamExternalMapping> builder)
        {
            builder
                .HasKey(x => new { x.TeamId, x.ProviderType });
            builder
                .Property(x => x.ExternalId)
                .IsRequired()
                .HasMaxLength(128);
            builder
                .Property(x => x.ProviderType)
                .IsRequired()
                .HasConversion(
                    v => (byte)v,
                    v => (DataProviderType)v);
        }
    }
}
