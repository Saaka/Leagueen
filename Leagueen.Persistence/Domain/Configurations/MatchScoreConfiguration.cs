using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leagueen.Persistence.Domain.Configurations
{
    public class MatchScoreConfiguration : IEntityTypeConfiguration<MatchScore>
    {
        public void Configure(EntityTypeBuilder<MatchScore> builder)
        {
            builder
                .HasKey(x => x.MatchScoreId);
            builder
                .Property(x => x.Result)
                .IsRequired()
                .HasConversion(
                    v => (byte)v,
                    v => (MatchResult)v);
            builder
                .Property(x => x.Duration)
                .IsRequired()
                .HasConversion(
                    v => (byte)v,
                    v => (MatchDuration)v);
        }
    }
}
