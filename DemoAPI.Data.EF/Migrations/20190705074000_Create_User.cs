using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoAPI.Data.EF.Migrations
{
    public partial class Create_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EntityStatus = table.Column<int>(nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 40, nullable: false),
                    LastName = table.Column<string>(maxLength: 40, nullable: false),
                    UserName = table.Column<string>(maxLength: 20, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 40, nullable: true),
                    AppreciationNumber = table.Column<int>(nullable: false),
                    MemberType = table.Column<int>(nullable: false),
                    PasswordSalt = table.Column<byte[]>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: false),
                    AllowTokensSince = table.Column<DateTimeOffset>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    SocialAccountId = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    AvatarUrl = table.Column<string>(nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    Gender = table.Column<int>(nullable: true),
                    LastLogin = table.Column<DateTimeOffset>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
