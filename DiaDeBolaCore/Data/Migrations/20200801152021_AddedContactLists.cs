using Microsoft.EntityFrameworkCore.Migrations;

namespace DiaDeBolaCore.Data.Migrations
{
    public partial class AddedContactLists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContactListId",
                table: "Contacts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContactLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    NumberOfElements = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactLists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactListId",
                table: "Contacts",
                column: "ContactListId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactLists_UserId",
                table: "ContactLists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_ContactLists_ContactListId",
                table: "Contacts",
                column: "ContactListId",
                principalTable: "ContactLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_ContactLists_ContactListId",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "ContactLists");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_ContactListId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactListId",
                table: "Contacts");
        }
    }
}
