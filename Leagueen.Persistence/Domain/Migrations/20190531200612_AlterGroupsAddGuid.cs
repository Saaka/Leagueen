using Microsoft.EntityFrameworkCore.Migrations;

namespace Leagueen.Persistence.Domain.Migrations
{
    public partial class AlterGroupsAddGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GroupGuid",
                schema: "leagueen",
                table: "Groups",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_GroupGuid",
                schema: "leagueen",
                table: "Groups",
                column: "GroupGuid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GroupGuid",
                schema: "leagueen",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "GroupGuid",
                schema: "leagueen",
                table: "Groups");
        }
    }
}
