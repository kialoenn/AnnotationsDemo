using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnnotationsDemo.Data.Migrations
{
    public partial class student : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PublicSchoolStudent",
                columns: table => new
                {
                    StudentNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    School = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Note = table.Column<string>(type: "NTEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    EmailConfirm = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicSchoolStudent", x => new { x.StudentNumber, x.School });
                });

            migrationBuilder.CreateIndex(
                name: "IX_PublicSchoolStudent_School",
                table: "PublicSchoolStudent",
                column: "School");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PublicSchoolStudent");
        }
    }
}
