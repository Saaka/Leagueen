using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leagueen.Persistence.Domain.Migrations
{
    public partial class AddedTeamAndTeamSeasonRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                schema: "leagueen",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    ShortName = table.Column<string>(maxLength: 32, nullable: false),
                    Tla = table.Column<string>(maxLength: 3, nullable: false),
                    CrestUrl = table.Column<string>(maxLength: 128, nullable: true),
                    Website = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "TeamSeasons",
                schema: "leagueen",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false),
                    SeasonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSeasons", x => new { x.TeamId, x.SeasonId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams",
                schema: "leagueen");

            migrationBuilder.DropTable(
                name: "TeamSeasons",
                schema: "leagueen");
        }
    }
}
