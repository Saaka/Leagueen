﻿// <auto-generated />
using System;
using Leagueen.Persistence.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Leagueen.Persistence.Domain.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190531200612_AlterGroupsAddGuid")]
    partial class AlterGroupsAddGuid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("leagueen")
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Leagueen.Domain.Entities.Competition", b =>
                {
                    b.Property<int>("CompetitionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.Property<int>("DataProviderId");

                    b.Property<int>("ExternalId");

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
                    b.Property<int>("DataProviderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<byte>("Type");

                    b.HasKey("DataProviderId");

                    b.ToTable("DataProviders");
                });

            modelBuilder.Entity("Leagueen.Domain.Entities.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<string>("GroupGuid")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<DateTime?>("LastUpdate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(null);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<int>("OwnerId");

                    b.Property<byte>("Status");

                    b.HasKey("GroupId");

                    b.HasIndex("GroupGuid")
                        .IsUnique()
                        .HasName("IX_GroupGuid");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Leagueen.Domain.Entities.GroupMember", b =>
                {
                    b.Property<int>("GroupMemberId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupId");

                    b.Property<bool>("IsActive");

                    b.Property<int>("Points");

                    b.Property<int>("UserId");

                    b.HasKey("GroupMemberId");

                    b.HasIndex("GroupId");

                    b.ToTable("GroupMembers");
                });

            modelBuilder.Entity("Leagueen.Domain.Entities.GroupSettings", b =>
                {
                    b.Property<int>("GroupSettingsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompetitionId");

                    b.Property<int>("GroupId");

                    b.Property<int>("PointsForExactScore");

                    b.Property<int>("PointsForResult");

                    b.Property<byte>("ResultResolveMode");

                    b.Property<int?>("SeasonId");

                    b.Property<byte>("Type");

                    b.Property<byte>("Visibility");

                    b.HasKey("GroupSettingsId");

                    b.HasIndex("CompetitionId");

                    b.HasIndex("GroupId")
                        .IsUnique();

                    b.HasIndex("SeasonId");

                    b.ToTable("GroupSettings");
                });

            modelBuilder.Entity("Leagueen.Domain.Entities.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AwayTeamId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("ExternalId");

                    b.Property<string>("Group")
                        .HasMaxLength(8);

                    b.Property<int>("HomeTeamId");

                    b.Property<DateTime>("LastProviderUpdate");

                    b.Property<int?>("Matchday");

                    b.Property<byte>("Result");

                    b.Property<int>("SeasonId");

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
                    b.Property<int>("MatchScoreId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Duration");

                    b.Property<int?>("ExtraTimeAway");

                    b.Property<int?>("ExtraTimeHome");

                    b.Property<int?>("FullTimeAway");

                    b.Property<int?>("FullTimeHome");

                    b.Property<int?>("HalfTimeAway");

                    b.Property<int?>("HalfTimeHome");

                    b.Property<int>("MatchId");

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
                    b.Property<int>("SeasonId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompetitionId");

                    b.Property<int>("CurrentMatchday");

                    b.Property<DateTime>("EndDate");

                    b.Property<int>("ExternalId");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("StartDate");

                    b.Property<int?>("WinnerId");

                    b.HasKey("SeasonId");

                    b.HasIndex("CompetitionId");

                    b.HasIndex("WinnerId");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("Leagueen.Domain.Entities.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CrestUrl")
                        .HasMaxLength(256);

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

            modelBuilder.Entity("Leagueen.Domain.Entities.TeamExternalMapping", b =>
                {
                    b.Property<int>("TeamId");

                    b.Property<byte>("ProviderType");

                    b.Property<string>("ExternalId")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("TeamId", "ProviderType");

                    b.ToTable("TeamExternalMappings");
                });

            modelBuilder.Entity("Leagueen.Domain.Entities.TeamSeason", b =>
                {
                    b.Property<int>("TeamId");

                    b.Property<int>("SeasonId");

                    b.HasKey("TeamId", "SeasonId");

                    b.HasIndex("SeasonId");

                    b.ToTable("TeamSeasons");
                });

            modelBuilder.Entity("Leagueen.Domain.Entities.UpdateLog", b =>
                {
                    b.Property<int>("UpdateLogId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte?>("CompetitionType");

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

            modelBuilder.Entity("Leagueen.Domain.Entities.GroupMember", b =>
                {
                    b.HasOne("Leagueen.Domain.Entities.Group", "Group")
                        .WithMany("GroupMembers")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Leagueen.Domain.Entities.GroupSettings", b =>
                {
                    b.HasOne("Leagueen.Domain.Entities.Competition")
                        .WithMany()
                        .HasForeignKey("CompetitionId");

                    b.HasOne("Leagueen.Domain.Entities.Group", "Group")
                        .WithOne("GroupSettings")
                        .HasForeignKey("Leagueen.Domain.Entities.GroupSettings", "GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Leagueen.Domain.Entities.Season")
                        .WithMany()
                        .HasForeignKey("SeasonId");
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

            modelBuilder.Entity("Leagueen.Domain.Entities.TeamExternalMapping", b =>
                {
                    b.HasOne("Leagueen.Domain.Entities.Team", "Team")
                        .WithMany("ExternalMappings")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
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
