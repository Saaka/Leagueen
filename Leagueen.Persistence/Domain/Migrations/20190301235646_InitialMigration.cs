using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leagueen.Persistence.Domain.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "leagueen");

            migrationBuilder.CreateTable(
                name: "Competitions",
                schema: "leagueen",
                columns: table => new
                {
                    CompetitionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    Code = table.Column<string>(maxLength: 16, nullable: true),
                    ExternalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.CompetitionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competitions",
                schema: "leagueen");
        }
    }
}
