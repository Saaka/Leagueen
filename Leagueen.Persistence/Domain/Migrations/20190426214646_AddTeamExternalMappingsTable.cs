using Microsoft.EntityFrameworkCore.Migrations;

namespace Leagueen.Persistence.Domain.Migrations
{
    public partial class AddTeamExternalMappingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamExternalMappings",
                schema: "leagueen",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false),
                    ProviderType = table.Column<byte>(nullable: false),
                    ExternalId = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamExternalMappings", x => new { x.TeamId, x.ProviderType });
                    table.ForeignKey(
                        name: "FK_TeamExternalMappings_Teams_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "leagueen",
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder
                .Sql($"INSERT INTO {PersistenceConstants.DefaultSchema}.TeamExternalMappings (TeamId, ExternalId, ProviderType) " +
                $"SELECT TeamId, ExternalId, '1' FROM {PersistenceConstants.DefaultSchema}.Teams");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamExternalMappings",
                schema: "leagueen");
        }
    }
}
