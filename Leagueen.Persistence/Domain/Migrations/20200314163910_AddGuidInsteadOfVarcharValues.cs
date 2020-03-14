using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leagueen.Persistence.Domain.Migrations
{
    public partial class AddGuidInsteadOfVarcharValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_UserGuid",
                schema: "leagueen",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserGuid",
                schema: "leagueen",
                table: "Users",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<Guid>(
                name: "GroupGuid",
                schema: "leagueen",
                table: "Groups",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<Guid>(
                name: "FriendshipRequestGuid",
                schema: "leagueen",
                table: "FriendshipRequests",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 64);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserGuid",
                schema: "leagueen",
                table: "Users",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(Guid),
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "GroupGuid",
                schema: "leagueen",
                table: "Groups",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "FriendshipRequestGuid",
                schema: "leagueen",
                table: "FriendshipRequests",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserGuid",
                schema: "leagueen",
                table: "Users",
                column: "UserGuid",
                unique: true);
        }
    }
}
