using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoAPI.Data.EF.Migrations
{
    public partial class Fix_Teacher_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mentor",
                table: "Teacher");

            migrationBuilder.AddColumn<Guid>(
                name: "MentorId",
                table: "Teacher",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MentorId",
                table: "Teacher");

            migrationBuilder.AddColumn<string>(
                name: "Mentor",
                table: "Teacher",
                nullable: false,
                defaultValue: "");
        }
    }
}
