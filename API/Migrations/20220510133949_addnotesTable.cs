﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_MySIRH.Migrations
{
    public partial class addnotesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Commenters_CommenterId",
                table: "Evaluations");

            migrationBuilder.DropIndex(
                name: "IX_Evaluations_CommenterId",
                table: "Evaluations");

            migrationBuilder.DropColumn(
                name: "CommenterId",
                table: "Evaluations");

            migrationBuilder.AddColumn<int>(
                name: "CommenterId",
                table: "Templates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Commenters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Templates_CommenterId",
                table: "Templates",
                column: "CommenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Templates_Commenters_CommenterId",
                table: "Templates",
                column: "CommenterId",
                principalTable: "Commenters",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Templates_Commenters_CommenterId",
                table: "Templates");

            migrationBuilder.DropIndex(
                name: "IX_Templates_CommenterId",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "CommenterId",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Commenters");

            migrationBuilder.AddColumn<int>(
                name: "CommenterId",
                table: "Evaluations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_CommenterId",
                table: "Evaluations",
                column: "CommenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Commenters_CommenterId",
                table: "Evaluations",
                column: "CommenterId",
                principalTable: "Commenters",
                principalColumn: "Id");
        }
    }
}
