using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialMediaForModelers.Migrations
{
    public partial class updatedUserPostData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostToComments",
                table: "PostToComments");

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "4bc31b2d-4e76-431c-8a05-72ac28c98939");

            migrationBuilder.DropColumn(
                name: "UserPageId",
                table: "PostToComments");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserPosts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "PostToComments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostToComments",
                table: "PostToComments",
                columns: new[] { "PostId", "CommentId" });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName", "UsersPageID" },
                values: new object[] { "662044de-eb39-4aa9-98ce-089aa21630ad", 0, "80da13c0-8512-4bea-8dd7-21e271f73330", new DateTime(1982, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "stubbste@gmail.com", false, "Trevor", "Stubbs", false, null, null, null, null, null, false, "bd9b2bb9-c527-48b6-bdc8-341745fec8d9", false, "1234", "stubbste@gmail.com", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostToComments",
                table: "PostToComments");

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "662044de-eb39-4aa9-98ce-089aa21630ad");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserPosts");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "PostToComments");

            migrationBuilder.AddColumn<int>(
                name: "UserPageId",
                table: "PostToComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostToComments",
                table: "PostToComments",
                columns: new[] { "UserPageId", "CommentId" });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName", "UsersPageID" },
                values: new object[] { "4bc31b2d-4e76-431c-8a05-72ac28c98939", 0, "73ccbb1c-4060-450c-87f9-08da8b55b7bc", new DateTime(1982, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "stubbste@gmail.com", false, "Trevor", "Stubbs", false, null, null, null, null, null, false, "9401bfb6-eb5b-48d4-bdf3-42f0243246d4", false, "1234", "stubbste@gmail.com", null });
        }
    }
}
