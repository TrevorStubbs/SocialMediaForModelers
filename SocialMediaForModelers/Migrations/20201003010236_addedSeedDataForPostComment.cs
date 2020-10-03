using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialMediaForModelers.Migrations
{
    public partial class addedSeedDataForPostComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "fde21a89-8fe7-496c-8339-e742f9410c66");

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName", "UsersPageID" },
                values: new object[] { "93789471-d30f-48eb-a40a-ba60c542ba94", 0, "2f3a2d9f-6723-494c-885b-7e52d18b65f8", new DateTime(1982, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "stubbste@gmail.com", false, "Trevor", "Stubbs", false, null, null, null, null, null, false, "cbb47e90-26ac-4c04-b71a-6e26a245b648", false, "1234", "stubbste@gmail.com", null });

            migrationBuilder.InsertData(
                table: "PostComments",
                columns: new[] { "ID", "Body", "UserId" },
                values: new object[] { 1, "I am a comment", "1234" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "93789471-d30f-48eb-a40a-ba60c542ba94");

            migrationBuilder.DeleteData(
                table: "PostComments",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName", "UsersPageID" },
                values: new object[] { "fde21a89-8fe7-496c-8339-e742f9410c66", 0, "c2d186e1-f7d7-41ce-9fbd-a6c6f0805521", new DateTime(1982, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "stubbste@gmail.com", false, "Trevor", "Stubbs", false, null, null, null, null, null, false, "fb33837e-b667-4979-9002-0baf3507f8b7", false, "1234", "stubbste@gmail.com", null });
        }
    }
}
