using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoAPI.Data.EF.Migrations
{
    public partial class ResetDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    AllowTokensSince = table.Column<DateTimeOffset>(nullable: true),
                    AppreciationNumber = table.Column<int>(nullable: false),
                    AvatarUrl = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(nullable: false),
                    DisplayName = table.Column<string>(maxLength: 40, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 40, nullable: false),
                    Gender = table.Column<int>(nullable: true),
                    LastLogin = table.Column<DateTimeOffset>(nullable: true),
                    LastName = table.Column<string>(maxLength: 40, nullable: false),
                    MemberType = table.Column<int>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: false),
                    PasswordSalt = table.Column<byte[]>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    SocialAccountId = table.Column<string>(nullable: true),
                    UpdatedTime = table.Column<DateTimeOffset>(nullable: false),
                    UserName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }
    }
}
