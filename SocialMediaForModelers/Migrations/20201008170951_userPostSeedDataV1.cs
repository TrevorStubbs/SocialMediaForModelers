using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialMediaForModelers.Migrations
{
    public partial class userPostSeedDataV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "662044de-eb39-4aa9-98ce-089aa21630ad");

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName", "UsersPageID" },
                values: new object[] { "3b0575c4-94e4-46f7-aeda-631520fae009", 0, "9815a6a3-ba77-49e5-942b-1efe4c653921", new DateTime(1982, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "stubbste@gmail.com", false, "Trevor", "Stubbs", false, null, null, null, null, null, false, "b6bdb1e0-f35c-4929-ae02-ad19975ea9c8", false, "1234", "stubbste@gmail.com", null });

            migrationBuilder.InsertData(
                table: "PostToComments",
                columns: new[] { "PostId", "CommentId", "PostCommentID", "UserPostID" },
                values: new object[] { 1, 1, null, null });

            migrationBuilder.InsertData(
                table: "PostToImages",
                columns: new[] { "PostId", "ImageId", "PostImageID", "UserPostID" },
                values: new object[] { 1, 1, null, null });

            migrationBuilder.InsertData(
                table: "UserPosts",
                columns: new[] { "ID", "Caption", "UserId" },
                values: new object[] { 1, "This is my post", "1234" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "3b0575c4-94e4-46f7-aeda-631520fae009");

            migrationBuilder.DeleteData(
                table: "PostToComments",
                keyColumns: new[] { "PostId", "CommentId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PostToImages",
                keyColumns: new[] { "PostId", "ImageId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UserPosts",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName", "UsersPageID" },
                values: new object[] { "662044de-eb39-4aa9-98ce-089aa21630ad", 0, "80da13c0-8512-4bea-8dd7-21e271f73330", new DateTime(1982, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "stubbste@gmail.com", false, "Trevor", "Stubbs", false, null, null, null, null, null, false, "bd9b2bb9-c527-48b6-bdc8-341745fec8d9", false, "1234", "stubbste@gmail.com", null });
        }
    }
}
