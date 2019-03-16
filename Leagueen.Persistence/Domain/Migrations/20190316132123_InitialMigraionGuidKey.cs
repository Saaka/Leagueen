using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leagueen.Persistence.Domain.Migrations
{
    public partial class InitialMigraionGuidKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "leagueen");

            migrationBuilder.CreateTable(
                name: "DataProviders",
                schema: "leagueen",
                columns: table => new
                {
                    DataProviderId = table.Column<Guid>(nullable: false),
                    Type = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataProviders", x => x.DataProviderId);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                schema: "leagueen",
                columns: table => new
                {
                    TeamId = table.Column<Guid>(nullable: false),
                    ExternalId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    ShortName = table.Column<string>(maxLength: 32, nullable: false),
                    Tla = table.Column<string>(maxLength: 3, nullable: false),
                    CrestUrl = table.Column<string>(maxLength: 256, nullable: true),
                    Website = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "UpdateLogs",
                schema: "leagueen",
                columns: table => new
                {
                    UpdateLogId = table.Column<Guid>(nullable: false),
                    LogType = table.Column<byte>(nullable: false),
                    ProviderType = table.Column<byte>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    IsExecuted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpdateLogs", x => x.UpdateLogId);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                schema: "leagueen",
                columns: table => new
                {
                    CompetitionId = table.Column<Guid>(nullable: false),
                    Type = table.Column<byte>(nullable: false),
                    Model = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Code = table.Column<string>(maxLength: 16, nullable: false),
                    ExternalId = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    DataProviderId = table.Column<Guid>(nullable: false),
                    LastProviderUpdate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.CompetitionId);
                    table.ForeignKey(
                        name: "FK_Competitions_DataProviders_DataProviderId",
                        column: x => x.DataProviderId,
                        principalSchema: "leagueen",
                        principalTable: "DataProviders",
                        principalColumn: "DataProviderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                schema: "leagueen",
                columns: table => new
                {
                    SeasonId = table.Column<Guid>(nullable: false),
                    CompetitionId = table.Column<Guid>(nullable: false),
                    ExternalId = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CurrentMatchday = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    WinnerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.SeasonId);
                    table.ForeignKey(
                        name: "FK_Seasons_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalSchema: "leagueen",
                        principalTable: "Competitions",
                        principalColumn: "CompetitionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seasons_Teams_WinnerId",
                        column: x => x.WinnerId,
                        principalSchema: "leagueen",
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                schema: "leagueen",
                columns: table => new
                {
                    MatchId = table.Column<Guid>(nullable: false),
                    ExternalId = table.Column<string>(nullable: true),
                    SeasonId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    Stage = table.Column<byte>(nullable: false),
                    Result = table.Column<byte>(nullable: false),
                    Group = table.Column<string>(maxLength: 8, nullable: true),
                    Matchday = table.Column<int>(nullable: true),
                    HomeTeamId = table.Column<Guid>(nullable: false),
                    AwayTeamId = table.Column<Guid>(nullable: false),
                    LastProviderUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalSchema: "leagueen",
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalSchema: "leagueen",
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalSchema: "leagueen",
                        principalTable: "Seasons",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamSeasons",
                schema: "leagueen",
                columns: table => new
                {
                    TeamId = table.Column<Guid>(nullable: false),
                    SeasonId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSeasons", x => new { x.TeamId, x.SeasonId });
                    table.ForeignKey(
                        name: "FK_TeamSeasons_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalSchema: "leagueen",
                        principalTable: "Seasons",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamSeasons_Teams_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "leagueen",
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchScores",
                schema: "leagueen",
                columns: table => new
                {
                    MatchScoreId = table.Column<Guid>(nullable: false),
                    MatchId = table.Column<Guid>(nullable: false),
                    Result = table.Column<byte>(nullable: false),
                    Duration = table.Column<byte>(nullable: false),
                    FullTimeHome = table.Column<int>(nullable: true),
                    FullTimeAway = table.Column<int>(nullable: true),
                    HalfTimeHome = table.Column<int>(nullable: true),
                    HalfTimeAway = table.Column<int>(nullable: true),
                    ExtraTimeHome = table.Column<int>(nullable: true),
                    ExtraTimeAway = table.Column<int>(nullable: true),
                    PentaltiesHome = table.Column<int>(nullable: true),
                    PentaltiesAway = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchScores", x => x.MatchScoreId);
                    table.ForeignKey(
                        name: "FK_MatchScores_Matches_MatchId",
                        column: x => x.MatchId,
                        principalSchema: "leagueen",
                        principalTable: "Matches",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_DataProviderId",
                schema: "leagueen",
                table: "Competitions",
                column: "DataProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AwayTeamId",
                schema: "leagueen",
                table: "Matches",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeTeamId",
                schema: "leagueen",
                table: "Matches",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_SeasonId",
                schema: "leagueen",
                table: "Matches",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchScores_MatchId",
                schema: "leagueen",
                table: "MatchScores",
                column: "MatchId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_CompetitionId",
                schema: "leagueen",
                table: "Seasons",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_WinnerId",
                schema: "leagueen",
                table: "Seasons",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSeasons_SeasonId",
                schema: "leagueen",
                table: "TeamSeasons",
                column: "SeasonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchScores",
                schema: "leagueen");

            migrationBuilder.DropTable(
                name: "TeamSeasons",
                schema: "leagueen");

            migrationBuilder.DropTable(
                name: "UpdateLogs",
                schema: "leagueen");

            migrationBuilder.DropTable(
                name: "Matches",
                schema: "leagueen");

            migrationBuilder.DropTable(
                name: "Seasons",
                schema: "leagueen");

            migrationBuilder.DropTable(
                name: "Competitions",
                schema: "leagueen");

            migrationBuilder.DropTable(
                name: "Teams",
                schema: "leagueen");

            migrationBuilder.DropTable(
                name: "DataProviders",
                schema: "leagueen");
        }
    }
}
