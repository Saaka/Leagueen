using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leagueen.Persistence.Domain.Migrations
{
    public partial class AddMatchAndMatchScoreTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                schema: "leagueen",
                columns: table => new
                {
                    MatchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExternalId = table.Column<int>(nullable: false),
                    SeasonId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    Stage = table.Column<byte>(nullable: false),
                    Result = table.Column<byte>(nullable: false),
                    Group = table.Column<string>(maxLength: 8, nullable: true),
                    Matchday = table.Column<int>(nullable: true),
                    HomeTeamId = table.Column<int>(nullable: false),
                    AwayTeamId = table.Column<int>(nullable: false),
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
                name: "MatchScores",
                schema: "leagueen",
                columns: table => new
                {
                    MatchScoreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MatchId = table.Column<int>(nullable: false),
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchScores",
                schema: "leagueen");

            migrationBuilder.DropTable(
                name: "Matches",
                schema: "leagueen");
        }
    }
}
