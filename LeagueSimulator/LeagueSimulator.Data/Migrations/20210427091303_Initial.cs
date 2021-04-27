using Microsoft.EntityFrameworkCore.Migrations;

namespace LeagueSimulator.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Attack = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Defense = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Chance = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
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
                    Point = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Win = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Draw = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Lose = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    GoalsScored = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    GoalsConceded = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Averaj = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TeamId = table.Column<int>(type: "int", nullable: false)
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
                    Week = table.Column<int>(type: "int", nullable: false),
                    HomeTeamId = table.Column<int>(type: "int", nullable: false),
                    AwayTeamId = table.Column<int>(type: "int", nullable: false),
                    HomeTeamGoal = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    AwayTeamGoal = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyResults_Teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id"
                        //onDelete: ReferentialAction.Cascade
                        );
                    table.ForeignKey(
                        name: "FK_WeeklyResults_Teams_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id"
                        //onDelete: ReferentialAction.Cascade
                        );
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Attack", "Chance", "Defense", "Name" },
                values: new object[,]
                {
                    { 1, 99, 99, 99, "Kocaelispor" },
                    { 2, 88, 85, 82, "Read Madrid" },
                    { 3, 90, 91, 80, "Barcalona" },
                    { 4, 92, 88, 85, "Bayern Münih" }
                });

            migrationBuilder.InsertData(
                table: "PuanTables",
                columns: new[] { "Id", "TeamId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "WeeklyResults",
                columns: new[] { "Id", "AwayTeamId", "HomeTeamId", "Week" },
                values: new object[,]
                {
                    { 1, 2, 1, 1 },
                    { 9, 3, 1, 5 },
                    { 11, 4, 1, 6 },
                    { 3, 3, 2, 2 },
                    { 6, 4, 2, 3 },
                    { 8, 1, 2, 4 },
                    { 2, 4, 3, 1 },
                    { 5, 1, 3, 3 },
                    { 12, 2, 3, 6 },
                    { 4, 1, 4, 2 },
                    { 7, 3, 4, 4 },
                    { 10, 2, 4, 5 }
                });

      

    
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
