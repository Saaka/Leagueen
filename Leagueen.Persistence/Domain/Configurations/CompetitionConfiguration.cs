using Leagueen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leagueen.Persistence.Domain.Configurations
{
    public class CompetitionConfiguration : IEntityTypeConfiguration<Competition>
    {
        public void Configure(EntityTypeBuilder<Competition> builder)
        {
            builder.HasKey(e => e.CompetitionId);

            builder
                .Property(x => x.Name)
                .HasMaxLength(64);

            builder
                .Property(x => x.Code)
                .HasMaxLength(16);
        }
    }
}
