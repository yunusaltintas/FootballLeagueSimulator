using Microsoft.EntityFrameworkCore.Migrations;

namespace LeagueSimulator.Data.Migrations
{
    public partial class edit4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Power",
                table: "Teams");

            migrationBuilder.AddColumn<int>(
                name: "Attack",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Chance",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defense",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attack",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Chance",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Defense",
                table: "Teams");

            migrationBuilder.AddColumn<double>(
                name: "Power",
                table: "Teams",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
