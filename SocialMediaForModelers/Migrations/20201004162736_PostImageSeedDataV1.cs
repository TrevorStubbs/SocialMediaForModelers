using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialMediaForModelers.Migrations
{
    public partial class PostImageSeedDataV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostToImages",
                table: "PostToImages");

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "93789471-d30f-48eb-a40a-ba60c542ba94");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "PostToImages");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "PostToImages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "PostImages",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostToImages",
                table: "PostToImages",
                columns: new[] { "PostId", "ImageId" });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName", "UsersPageID" },
                values: new object[] { "4bc31b2d-4e76-431c-8a05-72ac28c98939", 0, "73ccbb1c-4060-450c-87f9-08da8b55b7bc", new DateTime(1982, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "stubbste@gmail.com", false, "Trevor", "Stubbs", false, null, null, null, null, null, false, "9401bfb6-eb5b-48d4-bdf3-42f0243246d4", false, "1234", "stubbste@gmail.com", null });

            migrationBuilder.InsertData(
                table: "PostImages",
                columns: new[] { "ID", "ImageURI", "UserId" },
                values: new object[] { 1, "/Dog.png", "1234" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostToImages",
                table: "PostToImages");

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "4bc31b2d-4e76-431c-8a05-72ac28c98939");

            migrationBuilder.DeleteData(
                table: "PostImages",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "PostToImages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PostImages");

            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "PostToImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostToImages",
                table: "PostToImages",
                columns: new[] { "PostId", "PhotoId" });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName", "UsersPageID" },
                values: new object[] { "93789471-d30f-48eb-a40a-ba60c542ba94", 0, "2f3a2d9f-6723-494c-885b-7e52d18b65f8", new DateTime(1982, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "stubbste@gmail.com", false, "Trevor", "Stubbs", false, null, null, null, null, null, false, "cbb47e90-26ac-4c04-b71a-6e26a245b648", false, "1234", "stubbste@gmail.com", null });
        }
    }
}
