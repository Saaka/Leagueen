using Microsoft.EntityFrameworkCore.Migrations;

namespace Leagueen.Persistence.Domain.Migrations
{
    public partial class AddTeamSeasonRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TeamSeasons_SeasonId",
                schema: "leagueen",
                table: "TeamSeasons",
                column: "SeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamSeasons_Seasons_SeasonId",
                schema: "leagueen",
                table: "TeamSeasons",
                column: "SeasonId",
                principalSchema: "leagueen",
                principalTable: "Seasons",
                principalColumn: "SeasonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamSeasons_Teams_TeamId",
                schema: "leagueen",
                table: "TeamSeasons",
                column: "TeamId",
                principalSchema: "leagueen",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamSeasons_Seasons_SeasonId",
                schema: "leagueen",
                table: "TeamSeasons");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamSeasons_Teams_TeamId",
                schema: "leagueen",
                table: "TeamSeasons");

            migrationBuilder.DropIndex(
                name: "IX_TeamSeasons_SeasonId",
                schema: "leagueen",
                table: "TeamSeasons");
        }
    }
}
