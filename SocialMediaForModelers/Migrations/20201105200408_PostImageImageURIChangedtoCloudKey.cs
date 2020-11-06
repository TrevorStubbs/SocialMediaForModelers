using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialMediaForModelers.Migrations
{
    public partial class PostImageImageURIChangedtoCloudKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ec1a885-f5fe-4ada-9665-9a45da0b064a");

            migrationBuilder.DropColumn(
                name: "ImageURI",
                table: "PostImages");

            migrationBuilder.AddColumn<string>(
                name: "CloudStorageKey",
                table: "PostImages",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8fe8247e-2345-4fca-8412-489d2ccdcaee", 0, "4034e20d-4f45-4ae4-9c86-2d8aced96443", new DateTime(1982, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "stubbste@gmail.com", false, "Trevor", "Stubbs", false, null, null, null, null, null, false, "9e2ba19d-ef5b-4057-9a4a-79300ea1bd7c", false, "stubbste@gmail.com" });

            migrationBuilder.UpdateData(
                table: "PostImages",
                keyColumn: "ID",
                keyValue: 1,
                column: "CloudStorageKey",
                value: "/Dog.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8fe8247e-2345-4fca-8412-489d2ccdcaee");

            migrationBuilder.DropColumn(
                name: "CloudStorageKey",
                table: "PostImages");

            migrationBuilder.AddColumn<string>(
                name: "ImageURI",
                table: "PostImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3ec1a885-f5fe-4ada-9665-9a45da0b064a", 0, "af0e3cf4-4e14-473c-81b4-6142fb17344e", new DateTime(1982, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "stubbste@gmail.com", false, "Trevor", "Stubbs", false, null, null, null, null, null, false, "cf62a11e-414e-4ae8-bae7-1fd2ba50d7e3", false, "stubbste@gmail.com" });

            migrationBuilder.UpdateData(
                table: "PostImages",
                keyColumn: "ID",
                keyValue: 1,
                column: "ImageURI",
                value: "/Dog.png");
        }
    }
}
