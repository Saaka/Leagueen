using Microsoft.EntityFrameworkCore.Migrations;

namespace Leagueen.Persistence.Domain.Migrations
{
    public partial class AlterFriendshipRequestAddGuidMaxLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FriendshipRequest",
                schema: "leagueen",
                table: "FriendshipRequest");

            migrationBuilder.DropIndex(
                name: "IX_FriendshipRequestGuid",
                schema: "leagueen",
                table: "FriendshipRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friendship",
                schema: "leagueen",
                table: "Friendship");

            migrationBuilder.RenameTable(
                name: "FriendshipRequest",
                schema: "leagueen",
                newName: "FriendshipRequests",
                newSchema: "leagueen");

            migrationBuilder.RenameTable(
                name: "Friendship",
                schema: "leagueen",
                newName: "Friendships",
                newSchema: "leagueen");

            migrationBuilder.RenameIndex(
                name: "IX_Friendship_UserId",
                schema: "leagueen",
                table: "Friendships",
                newName: "IX_Friendships_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "FriendshipRequestGuid",
                schema: "leagueen",
                table: "FriendshipRequests",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FriendshipRequests",
                schema: "leagueen",
                table: "FriendshipRequests",
                column: "FriendshipRequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friendships",
                schema: "leagueen",
                table: "Friendships",
                column: "FriendshipId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendshipRequestGuid",
                schema: "leagueen",
                table: "FriendshipRequests",
                column: "FriendshipRequestGuid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Friendships",
                schema: "leagueen",
                table: "Friendships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FriendshipRequests",
                schema: "leagueen",
                table: "FriendshipRequests");

            migrationBuilder.DropIndex(
                name: "IX_FriendshipRequestGuid",
                schema: "leagueen",
                table: "FriendshipRequests");

            migrationBuilder.RenameTable(
                name: "Friendships",
                schema: "leagueen",
                newName: "Friendship",
                newSchema: "leagueen");

            migrationBuilder.RenameTable(
                name: "FriendshipRequests",
                schema: "leagueen",
                newName: "FriendshipRequest",
                newSchema: "leagueen");

            migrationBuilder.RenameIndex(
                name: "IX_Friendships_UserId",
                schema: "leagueen",
                table: "Friendship",
                newName: "IX_Friendship_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "FriendshipRequestGuid",
                schema: "leagueen",
                table: "FriendshipRequest",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 64);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friendship",
                schema: "leagueen",
                table: "Friendship",
                column: "FriendshipId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FriendshipRequest",
                schema: "leagueen",
                table: "FriendshipRequest",
                column: "FriendshipRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendshipRequestGuid",
                schema: "leagueen",
                table: "FriendshipRequest",
                column: "FriendshipRequestGuid",
                unique: true,
                filter: "[FriendshipRequestGuid] IS NOT NULL");
        }
    }
}
