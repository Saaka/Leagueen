using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leagueen.Persistence.Domain.Migrations
{
    public partial class CreateUserGuidIndexWithIncludedUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_UserGuid",
                schema: "leagueen",
                table: "Users",
                column: "UserGuid",
                unique: true)
                .Annotation("SqlServer:Include", new[] { "UserId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_UserGuid",
                schema: "leagueen",
                table: "Users");
        }
    }
}
