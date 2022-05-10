using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentWebApi.Migrations
{
    public partial class TwoMatchFiledsRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bracket",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "RoundNumber",
                table: "Match");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bracket",
                table: "Match",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RoundNumber",
                table: "Match",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
