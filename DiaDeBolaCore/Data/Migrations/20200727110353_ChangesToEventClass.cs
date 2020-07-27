using Microsoft.EntityFrameworkCore.Migrations;

namespace DiaDeBolaCore.Data.Migrations
{
    public partial class ChangesToEventClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Location_LocationId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventStatus_StatusId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_EquipmentColor_EquipmentColorId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Events_LocationId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_StatusId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentColor",
                table: "EquipmentColor");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "EquipmentColor",
                newName: "EquipmentColors");

            migrationBuilder.AddColumn<int>(
                name: "EventStatusId",
                table: "Events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Events",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentColors",
                table: "EquipmentColors",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventStatusId",
                table: "Events",
                column: "EventStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventStatus_EventStatusId",
                table: "Events",
                column: "EventStatusId",
                principalTable: "EventStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_EquipmentColors_EquipmentColorId",
                table: "Teams",
                column: "EquipmentColorId",
                principalTable: "EquipmentColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventStatus_EventStatusId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_EquipmentColors_EquipmentColorId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Events_EventStatusId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentColors",
                table: "EquipmentColors");

            migrationBuilder.DropColumn(
                name: "EventStatusId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "EquipmentColors",
                newName: "EquipmentColor");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentColor",
                table: "EquipmentColor",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_LocationId",
                table: "Events",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_StatusId",
                table: "Events",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Location_LocationId",
                table: "Events",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
