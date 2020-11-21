using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialMediaForModelers.Migrations
{
    public partial class addCreatedandModifiedTimesToSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13101a4f-bb4f-4fdd-843f-70d4095bc516");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "33edbe39-80ad-44fa-b1b5-46724f3991fa", 0, "90169416-0b49-4f1a-8377-905fff85ea6c", new DateTime(1982, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "stubbste@gmail.com", false, "Trevor", "Stubbs", false, null, null, null, null, null, false, "7feac926-bbe0-4c50-9e4e-f28525447738", false, "stubbste@gmail.com" });

            migrationBuilder.UpdateData(
                table: "PostComments",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2020, 11, 21, 23, 27, 49, 279, DateTimeKind.Utc).AddTicks(1441), new DateTime(2020, 11, 21, 23, 27, 49, 279, DateTimeKind.Utc).AddTicks(1441) });

            migrationBuilder.UpdateData(
                table: "PostImages",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2020, 11, 21, 23, 27, 49, 279, DateTimeKind.Utc).AddTicks(1441), new DateTime(2020, 11, 21, 23, 27, 49, 279, DateTimeKind.Utc).AddTicks(1441) });

            migrationBuilder.UpdateData(
                table: "UserPages",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2020, 11, 21, 23, 27, 49, 279, DateTimeKind.Utc).AddTicks(1441), new DateTime(2020, 11, 21, 23, 27, 49, 279, DateTimeKind.Utc).AddTicks(1441) });

            migrationBuilder.UpdateData(
                table: "UserPosts",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2020, 11, 21, 23, 27, 49, 279, DateTimeKind.Utc).AddTicks(1441), new DateTime(2020, 11, 21, 23, 27, 49, 279, DateTimeKind.Utc).AddTicks(1441) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33edbe39-80ad-44fa-b1b5-46724f3991fa");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "13101a4f-bb4f-4fdd-843f-70d4095bc516", 0, "374a4f15-9a67-4edb-84da-3db87fbbadbf", new DateTime(1982, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "stubbste@gmail.com", false, "Trevor", "Stubbs", false, null, null, null, null, null, false, "6ef1da8b-62b6-4751-ad81-e0e09a733e0f", false, "stubbste@gmail.com" });

            migrationBuilder.UpdateData(
                table: "PostComments",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "PostImages",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "UserPages",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "UserPosts",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
