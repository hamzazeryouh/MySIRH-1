using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_MySIRH.Migrations
{
    public partial class notetotemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Commenter",
                table: "Templates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NoteValue",
                table: "Templates",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Commenter",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "NoteValue",
                table: "Templates");
        }
    }
}
