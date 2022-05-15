using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_MySIRH.Migrations
{
    public partial class AddnoteToTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Templates_TemplateId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_TemplateId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "Notes");

            migrationBuilder.AddColumn<int>(
                name: "NotesId",
                table: "Templates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Templates_NotesId",
                table: "Templates",
                column: "NotesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Templates_Notes_NotesId",
                table: "Templates",
                column: "NotesId",
                principalTable: "Notes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Templates_Notes_NotesId",
                table: "Templates");

            migrationBuilder.DropIndex(
                name: "IX_Templates_NotesId",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "NotesId",
                table: "Templates");

            migrationBuilder.AddColumn<int>(
                name: "TemplateId",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_TemplateId",
                table: "Notes",
                column: "TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Templates_TemplateId",
                table: "Notes",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
