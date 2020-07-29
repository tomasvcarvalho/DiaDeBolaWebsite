using Microsoft.EntityFrameworkCore.Migrations;

namespace DiaDeBolaCore.Data.Migrations
{
    public partial class ReplacedLinkingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayersInTeam");

            migrationBuilder.DropTable(
                name: "TeamsInEvent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayersInTeam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PlayerStatusId = table.Column<int>(type: "int", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersInTeam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayersInTeam_AspNetUsers_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayersInTeam_PlayerStatus_PlayerStatusId",
                        column: x => x.PlayerStatusId,
                        principalTable: "PlayerStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayersInTeam_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamsInEvent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsInEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamsInEvent_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamsInEvent_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayersInTeam_PlayerId",
                table: "PlayersInTeam",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersInTeam_PlayerStatusId",
                table: "PlayersInTeam",
                column: "PlayerStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersInTeam_TeamId",
                table: "PlayersInTeam",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsInEvent_EventId",
                table: "TeamsInEvent",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsInEvent_TeamId",
                table: "TeamsInEvent",
                column: "TeamId");
        }
    }
}
