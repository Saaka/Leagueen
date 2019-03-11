using Leagueen.Domain.Entities;
using Leagueen.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leagueen.Persistence.Domain.Configurations
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder
                .HasKey(x => x.MatchId);
            builder
                .Property(x => x.Status)
                .IsRequired()
                .HasConversion(
                    v => (byte)v,
                    v => (MatchStatus)v);
            builder
                .Property(x => x.Stage)
                .IsRequired()
                .HasConversion(
                    v => (byte)v,
                    v => (MatchStage)v);
            builder
                .Property(x => x.Result)
                .IsRequired()
                .HasConversion(
                    v => (byte)v,
                    v => (MatchResult)v);
            builder
                .Property(x => x.Group)
                .IsRequired(false)
                .HasMaxLength(8);
            builder
                .HasOne(x => x.MatchScore)
                .WithOne(x => x.Match)
                .HasForeignKey<MatchScore>(x => x.MatchId)
                .IsRequired(false);
            builder
                .HasOne(x => x.HomeTeam)
                .WithMany(x => x.HomeMatches)
                .HasForeignKey(x => x.HomeTeamId);
            builder
                .HasOne(x => x.AwayTeam)
                .WithMany(x => x.AwayMatches)
                .HasForeignKey(x => x.AwayTeamId);
        }
    }
}
