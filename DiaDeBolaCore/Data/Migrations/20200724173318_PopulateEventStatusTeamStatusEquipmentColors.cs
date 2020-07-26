using Microsoft.EntityFrameworkCore.Migrations;


namespace DiaDeBolaCore.Data.Migrations
{
    public partial class PopulateEventStatusTeamStatusEquipmentColors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO EquipmentColor (Name) VALUES('Undefined')");
            migrationBuilder.Sql("INSERT INTO EquipmentColor (Name) VALUES('White')");
            migrationBuilder.Sql("INSERT INTO EquipmentColor (Name) VALUES('Dark')");

            migrationBuilder.Sql("INSERT INTO EventStatus (Name) VALUES('Created')");
            migrationBuilder.Sql("INSERT INTO EventStatus (Name) VALUES('Confirmed')");
            migrationBuilder.Sql("INSERT INTO EventStatus (Name) VALUES('Canceled')");
            migrationBuilder.Sql("INSERT INTO EventStatus (Name) VALUES('Finished')");

            migrationBuilder.Sql("INSERT INTO PlayerStatus (Name) VALUES('To be confirmed')");
            migrationBuilder.Sql("INSERT INTO PlayerStatus (Name) VALUES('Plays')");
            migrationBuilder.Sql("INSERT INTO PlayerStatus (Name) VALUES('Plays if he has to')");
            migrationBuilder.Sql("INSERT INTO PlayerStatus (Name) VALUES('Plays if possible')");
            migrationBuilder.Sql("INSERT INTO PlayerStatus (Name) VALUES('Does not play')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
