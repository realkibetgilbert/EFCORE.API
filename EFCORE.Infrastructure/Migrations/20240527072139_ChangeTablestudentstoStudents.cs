using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCORE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTablestudentstoStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluation_students_StudentId",
                table: "Evaluation");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentDetails_students_StudentId",
                table: "StudentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubject_students_StudentId",
                table: "StudentSubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_students",
                table: "students");

            migrationBuilder.RenameTable(
                name: "students",
                newName: "Students");

            migrationBuilder.RenameIndex(
                name: "IX_students_Name",
                table: "Students",
                newName: "IX_Students_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluation_Students_StudentId",
                table: "Evaluation",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentDetails_Students_StudentId",
                table: "StudentDetails",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubject_Students_StudentId",
                table: "StudentSubject",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluation_Students_StudentId",
                table: "Evaluation");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentDetails_Students_StudentId",
                table: "StudentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubject_Students_StudentId",
                table: "StudentSubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "students");

            migrationBuilder.RenameIndex(
                name: "IX_Students_Name",
                table: "students",
                newName: "IX_students_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_students",
                table: "students",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluation_students_StudentId",
                table: "Evaluation",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentDetails_students_StudentId",
                table: "StudentDetails",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubject_students_StudentId",
                table: "StudentSubject",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
