using Microsoft.EntityFrameworkCore.Migrations;

namespace Leagueen.Persistence.Domain.Migrations
{
    public partial class AddIsExecutedColumnToUpdateLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsExecuted",
                schema: "leagueen",
                table: "UpdateLogs",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsExecuted",
                schema: "leagueen",
                table: "UpdateLogs");
        }
    }
}
