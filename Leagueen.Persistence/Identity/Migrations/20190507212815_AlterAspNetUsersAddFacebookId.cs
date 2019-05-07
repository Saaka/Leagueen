using Microsoft.EntityFrameworkCore.Migrations;

namespace Leagueen.Persistence.Identity.Migrations
{
    public partial class AlterAspNetUsersAddFacebookId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FacebookId",
                schema: "leagueenidentity",
                table: "AspNetUsers",
                maxLength: 64,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacebookId",
                schema: "leagueenidentity",
                table: "AspNetUsers");
        }
    }
}
