using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leagueen.Persistence.Domain.Migrations
{
    public partial class AddFriendshipTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Friendship",
                schema: "leagueen",
                columns: table => new
                {
                    FriendshipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    FriendId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendship", x => x.FriendshipId);
                });

            migrationBuilder.CreateTable(
                name: "FriendshipRequest",
                schema: "leagueen",
                columns: table => new
                {
                    FriendshipRequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FriendshipRequestGuid = table.Column<string>(nullable: true),
                    RequesterId = table.Column<int>(nullable: false),
                    AddresseeId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendshipRequest", x => x.FriendshipRequestId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friendship_UserId",
                schema: "leagueen",
                table: "Friendship",
                column: "UserId")
                .Annotation("SqlServer:Include", new[] { "FriendId", "IsActive" });

            migrationBuilder.CreateIndex(
                name: "IX_FriendshipRequestGuid",
                schema: "leagueen",
                table: "FriendshipRequest",
                column: "FriendshipRequestGuid",
                unique: true,
                filter: "[FriendshipRequestGuid] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friendship",
                schema: "leagueen");

            migrationBuilder.DropTable(
                name: "FriendshipRequest",
                schema: "leagueen");
        }
    }
}
