using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialMediaForModelers.Migrations
{
    public partial class addedOwnerRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33edbe39-80ad-44fa-b1b5-46724f3991fa");

            migrationBuilder.UpdateData(
                table: "PostComments",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2020, 12, 1, 1, 5, 8, 577, DateTimeKind.Utc).AddTicks(9270), new DateTime(2020, 12, 1, 1, 5, 8, 577, DateTimeKind.Utc).AddTicks(9270) });

            migrationBuilder.UpdateData(
                table: "PostImages",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2020, 12, 1, 1, 5, 8, 577, DateTimeKind.Utc).AddTicks(9270), new DateTime(2020, 12, 1, 1, 5, 8, 577, DateTimeKind.Utc).AddTicks(9270) });

            migrationBuilder.UpdateData(
                table: "UserPages",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2020, 12, 1, 1, 5, 8, 577, DateTimeKind.Utc).AddTicks(9270), new DateTime(2020, 12, 1, 1, 5, 8, 577, DateTimeKind.Utc).AddTicks(9270) });

            migrationBuilder.UpdateData(
                table: "UserPosts",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2020, 12, 1, 1, 5, 8, 577, DateTimeKind.Utc).AddTicks(9270), new DateTime(2020, 12, 1, 1, 5, 8, 577, DateTimeKind.Utc).AddTicks(9270) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
