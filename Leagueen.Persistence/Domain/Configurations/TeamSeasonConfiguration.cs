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
        }
    }
}
