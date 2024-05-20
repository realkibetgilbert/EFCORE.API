﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCORE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OnDeleteStudentRestrict : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluation_students_StudentId",
                table: "Evaluation");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluation_students_StudentId",
                table: "Evaluation",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluation_students_StudentId",
                table: "Evaluation");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluation_students_StudentId",
                table: "Evaluation",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
