using Leagueen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leagueen.Persistence.Domain.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder
                .HasKey(x => x.TeamId);
            builder
                .Property(x => x.Name)
                .HasMaxLength(64)
                .IsRequired();
            builder
                .Property(x => x.ShortName)
                .HasMaxLength(32)
                .IsRequired();
            builder
                .Property(x => x.Tla)
                .HasMaxLength(3)
                .IsRequired();
            builder
                .Property(x => x.CrestUrl)
                .HasMaxLength(128)
                .IsRequired(false);
            builder
                .Property(x => x.Website)
                .HasMaxLength(128)
                .IsRequired(false);
            builder.Metadata
                .FindNavigation(nameof(Team.Seasons))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
            builder
                .HasMany(x => x.HomeMatches)
                .WithOne(x => x.HomeTeam)
                .HasForeignKey(x => x.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Metadata
                .FindNavigation(nameof(Team.HomeMatches))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
            builder
                .HasMany(x => x.AwayMatches)
                .WithOne(x => x.AwayTeam)
                .HasForeignKey(x => x.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Metadata
                .FindNavigation(nameof(Team.AwayMatches))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
