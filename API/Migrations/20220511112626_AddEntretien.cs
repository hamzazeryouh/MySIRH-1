using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_MySIRH.Migrations
{
    public partial class AddEntretien : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Templates_Evaluations_EvaluationId",
                table: "Templates");

            migrationBuilder.DropForeignKey(
                name: "FK_Templates_Notes_CommenterId",
                table: "Templates");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropIndex(
                name: "IX_Templates_CommenterId",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "CommenterId",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Templates");

            migrationBuilder.RenameColumn(
                name: "EvaluationId",
                table: "Templates",
                newName: "EntretienId");

            migrationBuilder.RenameIndex(
                name: "IX_Templates_EvaluationId",
                table: "Templates",
                newName: "IX_Templates_EntretienId");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Notes",
                newName: "Note");

            migrationBuilder.AddColumn<int>(
                name: "TemplateId",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Entretiens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Evaluateur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEntretien = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CandidatId = table.Column<int>(type: "int", nullable: false),
                    Commente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entretiens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entretiens_Candidats_CandidatId",
                        column: x => x.CandidatId,
                        principalTable: "Candidats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_TemplateId",
                table: "Notes",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Entretiens_CandidatId",
                table: "Entretiens",
                column: "CandidatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Templates_TemplateId",
                table: "Notes",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Templates_Entretiens_EntretienId",
                table: "Templates",
                column: "EntretienId",
                principalTable: "Entretiens",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Templates_TemplateId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Templates_Entretiens_EntretienId",
                table: "Templates");

            migrationBuilder.DropTable(
                name: "Entretiens");

            migrationBuilder.DropIndex(
                name: "IX_Notes_TemplateId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "EntretienId",
                table: "Templates",
                newName: "EvaluationId");

            migrationBuilder.RenameIndex(
                name: "IX_Templates_EntretienId",
                table: "Templates",
                newName: "IX_Templates_EvaluationId");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Notes",
                newName: "Notes");

            migrationBuilder.AddColumn<int>(
                name: "CommenterId",
                table: "Templates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Note",
                table: "Templates",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidatId = table.Column<int>(type: "int", nullable: false),
                    Commente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEntretien = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Evaluateur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluations_Candidats_CandidatId",
                        column: x => x.CandidatId,
                        principalTable: "Candidats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Templates_CommenterId",
                table: "Templates",
                column: "CommenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_CandidatId",
                table: "Evaluations",
                column: "CandidatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Templates_Evaluations_EvaluationId",
                table: "Templates",
                column: "EvaluationId",
                principalTable: "Evaluations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Templates_Notes_CommenterId",
                table: "Templates",
                column: "CommenterId",
                principalTable: "Notes",
                principalColumn: "Id");
        }
    }
}
