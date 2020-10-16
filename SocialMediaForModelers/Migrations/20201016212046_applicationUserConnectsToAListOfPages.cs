using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialMediaForModelers.Migrations
{
    public partial class applicationUserConnectsToAListOfPages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_UserPages_UsersPageID",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_UsersPageID",
                table: "AppUsers");

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "543c01a4-6964-4fdd-b0b0-be31f78b2d41");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "UsersPageID",
                table: "AppUsers");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "UserPages",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "564fe961-1541-4066-9533-d2d316759ab3", 0, "e59f85a3-46b6-4e38-8ea5-ebc0022ec67e", new DateTime(1982, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "stubbste@gmail.com", false, "Trevor", "Stubbs", false, null, null, null, null, null, false, "576d6bc3-9c18-437f-b4d9-740defc36dbf", false, "stubbste@gmail.com" });

            migrationBuilder.CreateIndex(
                name: "IX_UserPages_ApplicationUserId",
                table: "UserPages",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPages_AppUsers_ApplicationUserId",
                table: "UserPages",
                column: "ApplicationUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPages_AppUsers_ApplicationUserId",
                table: "UserPages");

            migrationBuilder.DropIndex(
                name: "IX_UserPages_ApplicationUserId",
                table: "UserPages");

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "564fe961-1541-4066-9533-d2d316759ab3");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserPages");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsersPageID",
                table: "AppUsers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName", "UsersPageID" },
                values: new object[] { "543c01a4-6964-4fdd-b0b0-be31f78b2d41", 0, "85ea8159-b6ec-44c3-bf56-274af7c3c413", new DateTime(1982, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "stubbste@gmail.com", false, "Trevor", "Stubbs", false, null, null, null, null, null, false, "d865313a-b376-4b9a-a6e2-48f3aea006b7", false, "1234", "stubbste@gmail.com", null });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_UsersPageID",
                table: "AppUsers",
                column: "UsersPageID");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_UserPages_UsersPageID",
                table: "AppUsers",
                column: "UsersPageID",
                principalTable: "UserPages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
