using Leagueen.Persistence.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leagueen.Persistence.Identity.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .Property(e => e.Moniker)
                .IsRequired()
                .HasMaxLength(64);

            builder
                .Property(e => e.GoogleId)
                .IsRequired(false)
                .HasMaxLength(64);

            builder
                .Property(e => e.FacebookId)
                .IsRequired(false)
                .HasMaxLength(64);

            builder
                .Property(e => e.DisplayName)
                .IsRequired(true)
                .HasMaxLength(128);

            builder
                .Property(e => e.ImageUrl)
                .IsRequired(false)
                .HasMaxLength(1024);
        }
    }
}
