using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leagueen.Persistence.Domain.Migrations
{
    public partial class CreateCompetitionUpdatestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompetitionUpdates",
                schema: "leagueen",
                columns: table => new
                {
                    CompetitionUpdateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompetitionId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionUpdates", x => x.CompetitionUpdateId);
                    table.ForeignKey(
                        name: "FK_CompetitionUpdates_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalSchema: "leagueen",
                        principalTable: "Competitions",
                        principalColumn: "CompetitionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionUpdates_CompetitionId",
                schema: "leagueen",
                table: "CompetitionUpdates",
                column: "CompetitionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetitionUpdates",
                schema: "leagueen");
        }
    }
}
