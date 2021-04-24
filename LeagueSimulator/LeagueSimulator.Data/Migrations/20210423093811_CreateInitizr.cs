using Microsoft.EntityFrameworkCore.Migrations;

namespace LeagueSimulator.Data.Migrations
{
    public partial class CreateInitizr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Power = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PuanTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Point = table.Column<int>(type: "int", nullable: true),
                    Win = table.Column<int>(type: "int", nullable: true),
                    Draw = table.Column<int>(type: "int", nullable: true),
                    Lose = table.Column<int>(type: "int", nullable: true),
                    GoalsScored = table.Column<int>(type: "int", nullable: true),
                    GoalsConceded = table.Column<int>(type: "int", nullable: true),
                    Averaj = table.Column<int>(type: "int", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuanTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PuanTables_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Week = table.Column<int>(type: "int", nullable: true),
                    HomeTeamId = table.Column<int>(type: "int", nullable: true),
                    AwayTeamId = table.Column<int>(type: "int", nullable: true),
                    HomeTeamGoal = table.Column<int>(type: "int", nullable: true),
                    AwayTeamGoal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyResults_Teams_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PuanTables_TeamId",
                table: "PuanTables",
                column: "TeamId",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyResults_AwayTeamId",
                table: "WeeklyResults",
                column: "AwayTeamId",
                unique: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PuanTables");

            migrationBuilder.DropTable(
                name: "WeeklyResults");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
