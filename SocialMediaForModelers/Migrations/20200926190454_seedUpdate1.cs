using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialMediaForModelers.Migrations
{
    public partial class seedUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "886d49b7-456b-4a51-8d9e-6305c067588f");

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName", "UsersPageID" },
                values: new object[] { "a90b7c0d-9588-47ba-abfa-35030dc6a110", 0, "2939859c-8b27-46ce-b0f9-d5c116b8a7f9", new DateTime(1982, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "stubbste@gmail.com", false, "Trevor", "Stubbs", false, null, null, null, null, null, false, "b8da5b41-c5a9-4334-9b73-acd49645e974", false, "1234", "stubbste@gmail.com", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "a90b7c0d-9588-47ba-abfa-35030dc6a110");

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName", "UsersPageID" },
                values: new object[] { "886d49b7-456b-4a51-8d9e-6305c067588f", 0, "8173bfd1-88ec-4740-b816-f26397dc036e", new DateTime(1982, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Trevor", "Stubbs", false, null, null, null, null, null, false, "50002e06-d1a6-45e7-addf-305ba8223949", false, "1234", null, null });
        }
    }
}
