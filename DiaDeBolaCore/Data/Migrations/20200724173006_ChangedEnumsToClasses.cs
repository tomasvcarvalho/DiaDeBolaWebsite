using Microsoft.EntityFrameworkCore.Migrations;

namespace DiaDeBolaCore.Data.Migrations
{
    public partial class ChangedEnumsToClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquipmentColor",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentColorId",
                table: "Teams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayerStatusId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EquipmentColor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentColor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_EquipmentColorId",
                table: "Teams",
                column: "EquipmentColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_StatusId",
                table: "Events",
                column: "StatusId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventStatus_StatusId",
                table: "Events",
                column: "StatusId",
                principalTable: "EventStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_EquipmentColor_EquipmentColorId",
                table: "Teams",
                column: "EquipmentColorId",
                principalTable: "EquipmentColor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PlayerStatus_PlayerStatusId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventStatus_StatusId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_EquipmentColor_EquipmentColorId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "EquipmentColor");

            migrationBuilder.DropTable(
                name: "EventStatus");

            migrationBuilder.DropTable(
                name: "PlayerStatus");

            migrationBuilder.DropIndex(
                name: "IX_Teams_EquipmentColorId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Events_StatusId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PlayerStatusId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EquipmentColorId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "PlayerStatusId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentColor",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }
    }
}
