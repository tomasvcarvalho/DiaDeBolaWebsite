using Microsoft.EntityFrameworkCore.Migrations;

namespace DiaDeBolaCore.Data.Migrations
{
    public partial class CorrectedPlayerClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PlayerStatus_PlayerStatusId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PlayerStatusId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PlayerStatusId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "PlayerStatusId",
                table: "PlayersInTeam",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId1 = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_PlayerStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "PlayerStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Players_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayersInTeam_PlayerStatusId",
                table: "PlayersInTeam",
                column: "PlayerStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_StatusId",
                table: "Players",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserId1",
                table: "Players",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersInTeam_PlayerStatus_PlayerStatusId",
                table: "PlayersInTeam",
                column: "PlayerStatusId",
                principalTable: "PlayerStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayersInTeam_PlayerStatus_PlayerStatusId",
                table: "PlayersInTeam");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropIndex(
                name: "IX_PlayersInTeam_PlayerStatusId",
                table: "PlayersInTeam");

            migrationBuilder.DropColumn(
                name: "PlayerStatusId",
                table: "PlayersInTeam");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PlayerStatusId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PlayerStatusId",
                table: "AspNetUsers",
                column: "PlayerStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PlayerStatus_PlayerStatusId",
                table: "AspNetUsers",
                column: "PlayerStatusId",
                principalTable: "PlayerStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
