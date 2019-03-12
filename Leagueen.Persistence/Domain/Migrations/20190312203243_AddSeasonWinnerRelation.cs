using Microsoft.EntityFrameworkCore.Migrations;

namespace Leagueen.Persistence.Domain.Migrations
{
    public partial class AddSeasonWinnerRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Seasons_WinnerId",
                schema: "leagueen",
                table: "Seasons",
                column: "WinnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Teams_WinnerId",
                schema: "leagueen",
                table: "Seasons",
                column: "WinnerId",
                principalSchema: "leagueen",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Teams_WinnerId",
                schema: "leagueen",
                table: "Seasons");

            migrationBuilder.DropIndex(
                name: "IX_Seasons_WinnerId",
                schema: "leagueen",
                table: "Seasons");
        }
    }
}
