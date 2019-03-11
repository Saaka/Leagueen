using Leagueen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leagueen.Persistence.Domain.Configurations
{
    public class TeamSeasonConfiguration : IEntityTypeConfiguration<TeamSeason>
    {
        public void Configure(EntityTypeBuilder<TeamSeason> builder)
        {
            builder
                .HasKey(x => new { x.TeamId, x.SeasonId });
            builder
                .HasOne(x => x.Team)
                .WithMany(x => x.Seasons)
                .HasForeignKey(x => x.TeamId);
            builder
                .HasOne(x => x.Season)
                .WithMany(x => x.Teams)
                .HasForeignKey(x => x.SeasonId);
        }
    }
}
