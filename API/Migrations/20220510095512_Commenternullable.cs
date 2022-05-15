using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_MySIRH.Migrations
{
    public partial class Commenternullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Notes_CommenterId",
                table: "Evaluations");

            migrationBuilder.AlterColumn<int>(
                name: "CommenterId",
                table: "Evaluations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Notes_CommenterId",
                table: "Evaluations",
                column: "CommenterId",
                principalTable: "Notes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Notes_CommenterId",
                table: "Evaluations");

            migrationBuilder.AlterColumn<int>(
                name: "CommenterId",
                table: "Evaluations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Notes_CommenterId",
                table: "Evaluations",
                column: "CommenterId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
