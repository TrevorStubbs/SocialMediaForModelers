using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialMediaForModelers.Migrations
{
    public partial class ownerRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PostComments",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Created", "Modified", "UserId" },
                values: new object[] { new DateTime(2020, 12, 1, 19, 54, 24, 717, DateTimeKind.Utc).AddTicks(7881), new DateTime(2020, 12, 1, 19, 54, 24, 717, DateTimeKind.Utc).AddTicks(7881), "fc2155ec-7184-4dd8-a45e-2ea07e8cc5ea" });

            migrationBuilder.UpdateData(
                table: "PostImages",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Created", "Modified", "UserId" },
                values: new object[] { new DateTime(2020, 12, 1, 19, 54, 24, 717, DateTimeKind.Utc).AddTicks(7881), new DateTime(2020, 12, 1, 19, 54, 24, 717, DateTimeKind.Utc).AddTicks(7881), "fc2155ec-7184-4dd8-a45e-2ea07e8cc5ea" });

            migrationBuilder.UpdateData(
                table: "UserPages",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Created", "Modified", "UserId" },
                values: new object[] { new DateTime(2020, 12, 1, 19, 54, 24, 717, DateTimeKind.Utc).AddTicks(7881), new DateTime(2020, 12, 1, 19, 54, 24, 717, DateTimeKind.Utc).AddTicks(7881), "fc2155ec-7184-4dd8-a45e-2ea07e8cc5ea" });

            migrationBuilder.UpdateData(
                table: "UserPosts",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Created", "Modified", "UserId" },
                values: new object[] { new DateTime(2020, 12, 1, 19, 54, 24, 717, DateTimeKind.Utc).AddTicks(7881), new DateTime(2020, 12, 1, 19, 54, 24, 717, DateTimeKind.Utc).AddTicks(7881), "fc2155ec-7184-4dd8-a45e-2ea07e8cc5ea" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PostComments",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Created", "Modified", "UserId" },
                values: new object[] { new DateTime(2020, 12, 1, 1, 5, 8, 577, DateTimeKind.Utc).AddTicks(9270), new DateTime(2020, 12, 1, 1, 5, 8, 577, DateTimeKind.Utc).AddTicks(9270), "1234" });

            migrationBuilder.UpdateData(
                table: "PostImages",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Created", "Modified", "UserId" },
                values: new object[] { new DateTime(2020, 12, 1, 1, 5, 8, 577, DateTimeKind.Utc).AddTicks(9270), new DateTime(2020, 12, 1, 1, 5, 8, 577, DateTimeKind.Utc).AddTicks(9270), "1234" });

            migrationBuilder.UpdateData(
                table: "UserPages",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Created", "Modified", "UserId" },
                values: new object[] { new DateTime(2020, 12, 1, 1, 5, 8, 577, DateTimeKind.Utc).AddTicks(9270), new DateTime(2020, 12, 1, 1, 5, 8, 577, DateTimeKind.Utc).AddTicks(9270), "1234" });

            migrationBuilder.UpdateData(
                table: "UserPosts",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Created", "Modified", "UserId" },
                values: new object[] { new DateTime(2020, 12, 1, 1, 5, 8, 577, DateTimeKind.Utc).AddTicks(9270), new DateTime(2020, 12, 1, 1, 5, 8, 577, DateTimeKind.Utc).AddTicks(9270), "1234" });
        }
    }
}
