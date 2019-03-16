﻿// <auto-generated />
using System;
using Leagueen.Persistence.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Leagueen.Persistence.Domain.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("leagueen")
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Leagueen.Domain.Entities.Competition", b =>
                {
                    b.Property<Guid>("CompetitionId");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.Property<Guid>("DataProviderId");

                    b.Property<string>("ExternalId");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime?>("LastProviderUpdate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(null);

                    b.Property<byte>("Model");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<byte>("Type");

                    b.HasKey("CompetitionId");

                    b.HasIndex("DataProviderId");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("Leagueen.Domain.Entities.DataProvider", b =>
                {
                    b.Property<Guid>("DataProviderId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<byte>("Type");

                    b.HasKey("DataProviderId");

                    b.ToTable("DataProviders");
                });

            modelBuilder.Entity("Leagueen.Domain.Entities.Match", b =>
                {
                    b.Property<Guid>("MatchId");

                    b.Property<Guid>("AwayTeamId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("ExternalId");

                    b.Property<string>("Group")
                        .HasMaxLength(8);

                    b.Property<Guid>("HomeTeamId");

                    b.Property<DateTime>("LastProviderUpdate");

                    b.Property<int?>("Matchday");

                    b.Property<byte>("Result");

                    b.Property<Guid>("SeasonId");

                    b.Property<byte>("Stage");

                    b.Property<byte>("Status");

                    b.HasKey("MatchId");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("HomeTeamId");

                    b.HasIndex("SeasonId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Leagueen.Domain.Entities.MatchScore", b =>
                {
                    b.Property<Guid>("MatchScoreId");

                    b.Property<byte>("Duration");

                    b.Property<int?>("ExtraTimeAway");

                    b.Property<int?>("ExtraTimeHome");

                    b.Property<int?>("FullTimeAway");

                    b.Property<int?>("FullTimeHome");

                    b.Property<int?>("HalfTimeAway");

                    b.Property<int?>("HalfTimeHome");

                    b.Property<Guid>("MatchId");

                    b.Property<int?>("PentaltiesAway");

                    b.Property<int?>("PentaltiesHome");

                    b.Property<byte>("Result");

                    b.HasKey("MatchScoreId");

                    b.HasIndex("MatchId")
                        .IsUnique();

                    b.ToTable("MatchScores");
                });

            modelBuilder.Entity("Leagueen.Domain.Entities.Season", b =>
                {
                    b.Property<Guid>("SeasonId");

                    b.Property<Guid>("CompetitionId");

                    b.Property<int>("CurrentMatchday");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("ExternalId")
                        .IsRequired();

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("StartDate");

                    b.Property<Guid?>("WinnerId");

                    b.HasKey("SeasonId");

                    b.HasIndex("CompetitionId");

                    b.HasIndex("WinnerId");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("Leagueen.Domain.Entities.Team", b =>
                {
                    b.Property<Guid>("TeamId");

                    b.Property<string>("CrestUrl")
                        .HasMaxLength(256);

                    b.Property<string>("ExternalId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<string>("Tla")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.Property<string>("Website")
                        .HasMaxLength(128);

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Leagueen.Domain.Entities.TeamSeason", b =>
                {
                    b.Property<Guid>("TeamId");

                    b.Property<Guid>("SeasonId");

                    b.HasKey("TeamId", "SeasonId");

                    b.HasIndex("SeasonId");

                    b.ToTable("TeamSeasons");
                });

            modelBuilder.Entity("Leagueen.Domain.Entities.UpdateLog", b =>
                {
                    b.Property<Guid>("UpdateLogId");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("IsExecuted");

                    b.Property<byte>("LogType");

                    b.Property<byte>("ProviderType");

                    b.HasKey("UpdateLogId");

                    b.ToTable("UpdateLogs");
                });

            modelBuilder.Entity("Leagueen.Domain.Entities.Competition", b =>
                {
                    b.HasOne("Leagueen.Domain.Entities.DataProvider", "DataProvider")
                        .WithMany("Competitions")
                        .HasForeignKey("DataProviderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Leagueen.Domain.Entities.Match", b =>
                {
                    b.HasOne("Leagueen.Domain.Entities.Team", "AwayTeam")
                        .WithMany("AwayMatches")
                        .HasForeignKey("AwayTeamId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Leagueen.Domain.Entities.Team", "HomeTeam")
                        .WithMany("HomeMatches")
                        .HasForeignKey("HomeTeamId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Leagueen.Domain.Entities.Season", "Season")
                        .WithMany("Matches")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Leagueen.Domain.Entities.MatchScore", b =>
                {
                    b.HasOne("Leagueen.Domain.Entities.Match", "Match")
                        .WithOne("MatchScore")
                        .HasForeignKey("Leagueen.Domain.Entities.MatchScore", "MatchId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Leagueen.Domain.Entities.Season", b =>
                {
                    b.HasOne("Leagueen.Domain.Entities.Competition", "Competition")
                        .WithMany("Seasons")
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Leagueen.Domain.Entities.Team", "Winner")
                        .WithMany("WonSeasons")
                        .HasForeignKey("WinnerId");
                });

            modelBuilder.Entity("Leagueen.Domain.Entities.TeamSeason", b =>
                {
                    b.HasOne("Leagueen.Domain.Entities.Season", "Season")
                        .WithMany("Teams")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Leagueen.Domain.Entities.Team", "Team")
                        .WithMany("Seasons")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
