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
                    b.Property<int>("CompetitionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.Property<int>("ExternalId");

                    b.Property<DateTime?>("LastProviderUpdate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(null);

                    b.Property<byte>("Model");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<byte>("Type");

                    b.HasKey("CompetitionId");

                    b.ToTable("Competitions");
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

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("Leagueen.Domain.Entities.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CrestUrl")
                        .HasMaxLength(128);

                    b.Property<int>("ExternalId");

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
                    b.Property<int>("TeamId");

                    b.Property<int>("SeasonId");

                    b.HasKey("TeamId", "SeasonId");

                    b.HasIndex("SeasonId");

                    b.ToTable("TeamSeasons");
                });

            modelBuilder.Entity("Leagueen.Domain.Entities.Season", b =>
                {
                    b.HasOne("Leagueen.Domain.Entities.Competition", "Competition")
                        .WithMany("Seasons")
                        .HasForeignKey("CompetitionId")
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
