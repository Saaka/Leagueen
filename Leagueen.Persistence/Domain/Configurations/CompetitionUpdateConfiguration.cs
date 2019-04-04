using Leagueen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leagueen.Persistence.Domain.Configurations
{
    public class CompetitionUpdateConfiguration : IEntityTypeConfiguration<CompetitionUpdate>
    {
        public void Configure(EntityTypeBuilder<CompetitionUpdate> builder)
        {
            builder
                .HasKey(x => x.CompetitionUpdateId);
            builder
                .HasOne(x => x.Competition)
                .WithMany(x => x.CompetitionUpdates)
                .HasForeignKey(x => x.CompetitionId);
            builder
                .Property(x => x.Date)
                .IsRequired(true);
        }
    }
}
