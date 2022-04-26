using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentWebApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tournament",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumberOfContestants = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournament", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tournament_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionNumber = table.Column<int>(type: "int", nullable: false),
                    Bracket = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoundNumber = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CourtNumber = table.Column<int>(type: "int", nullable: true),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    FirstTeamScore = table.Column<int>(type: "int", nullable: true),
                    SecondTeamScore = table.Column<int>(type: "int", nullable: true),
                    FirstTeamId = table.Column<int>(type: "int", nullable: true),
                    SecondTeamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_Team_FirstTeamId",
                        column: x => x.FirstTeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Team_SecondTeamId",
                        column: x => x.SecondTeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Match_FirstTeamId",
                table: "Match",
                column: "FirstTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_SecondTeamId",
                table: "Match",
                column: "SecondTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_TournamentId",
                table: "Match",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournament_Name",
                table: "Tournament",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tournament_UserId",
                table: "Tournament",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Tournament");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
