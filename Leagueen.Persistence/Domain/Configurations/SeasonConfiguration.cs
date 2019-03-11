using Leagueen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leagueen.Persistence.Domain.Configurations
{
    public class SeasonConfiguration : IEntityTypeConfiguration<Season>
    {
        public void Configure(EntityTypeBuilder<Season> builder)
        {
            builder
                .HasKey(e => e.SeasonId);
            builder
                .Property(x => x.CompetitionId)
                .IsRequired();
            builder
                .Property(x => x.ExternalId)
                .IsRequired();
            builder
                .Property(x => x.EndDate)
                .IsRequired();
            builder
                .Property(x => x.StartDate)
                .IsRequired();
            builder
                .Property(x => x.CurrentMatchday)
                .IsRequired();
            builder
                .Property(x => x.IsActive)
                .IsRequired();            
            builder.Metadata
                .FindNavigation(nameof(Season.Teams))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
