using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialMediaForModelers.Migrations
{
    public partial class UserPageSeedDataV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pageLikes_UserPages_UserPageID",
                table: "pageLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPageToPosts_UserPages_UserPageId",
                table: "UserPageToPosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPageToPosts",
                table: "UserPageToPosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pageLikes",
                table: "pageLikes");

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "3b0575c4-94e4-46f7-aeda-631520fae009");

            migrationBuilder.RenameTable(
                name: "pageLikes",
                newName: "PageLikes");

            migrationBuilder.RenameColumn(
                name: "UserPageId",
                table: "UserPageToPosts",
                newName: "UserPageID");

            migrationBuilder.RenameIndex(
                name: "IX_pageLikes_UserPageID",
                table: "PageLikes",
                newName: "IX_PageLikes_UserPageID");

            migrationBuilder.AlterColumn<int>(
                name: "UserPageID",
                table: "UserPageToPosts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PageId",
                table: "UserPageToPosts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserPages",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPageToPosts",
                table: "UserPageToPosts",
                columns: new[] { "PageId", "PostId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PageLikes",
                table: "PageLikes",
                columns: new[] { "PageId", "UserId" });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName", "UsersPageID" },
                values: new object[] { "543c01a4-6964-4fdd-b0b0-be31f78b2d41", 0, "85ea8159-b6ec-44c3-bf56-274af7c3c413", new DateTime(1982, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "stubbste@gmail.com", false, "Trevor", "Stubbs", false, null, null, null, null, null, false, "d865313a-b376-4b9a-a6e2-48f3aea006b7", false, "1234", "stubbste@gmail.com", null });

            migrationBuilder.InsertData(
                table: "UserPageToPosts",
                columns: new[] { "PageId", "PostId", "UserPageID", "UserPostID" },
                values: new object[] { 1, 1, null, null });

            migrationBuilder.InsertData(
                table: "UserPages",
                columns: new[] { "ID", "PageContent", "PageName", "UserId" },
                values: new object[] { 1, "I am I here", "Seed Page", "1234" });

            migrationBuilder.CreateIndex(
                name: "IX_UserPageToPosts_UserPageID",
                table: "UserPageToPosts",
                column: "UserPageID");

            migrationBuilder.AddForeignKey(
                name: "FK_PageLikes_UserPages_UserPageID",
                table: "PageLikes",
                column: "UserPageID",
                principalTable: "UserPages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPageToPosts_UserPages_UserPageID",
                table: "UserPageToPosts",
                column: "UserPageID",
                principalTable: "UserPages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PageLikes_UserPages_UserPageID",
                table: "PageLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPageToPosts_UserPages_UserPageID",
                table: "UserPageToPosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPageToPosts",
                table: "UserPageToPosts");

            migrationBuilder.DropIndex(
                name: "IX_UserPageToPosts_UserPageID",
                table: "UserPageToPosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PageLikes",
                table: "PageLikes");

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "543c01a4-6964-4fdd-b0b0-be31f78b2d41");

            migrationBuilder.DeleteData(
                table: "UserPageToPosts",
                keyColumns: new[] { "PageId", "PostId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UserPages",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "PageId",
                table: "UserPageToPosts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserPages");

            migrationBuilder.RenameTable(
                name: "PageLikes",
                newName: "pageLikes");

            migrationBuilder.RenameColumn(
                name: "UserPageID",
                table: "UserPageToPosts",
                newName: "UserPageId");

            migrationBuilder.RenameIndex(
                name: "IX_PageLikes_UserPageID",
                table: "pageLikes",
                newName: "IX_pageLikes_UserPageID");

            migrationBuilder.AlterColumn<int>(
                name: "UserPageId",
                table: "UserPageToPosts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPageToPosts",
                table: "UserPageToPosts",
                columns: new[] { "UserPageId", "PostId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_pageLikes",
                table: "pageLikes",
                columns: new[] { "PageId", "UserId" });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName", "UsersPageID" },
                values: new object[] { "3b0575c4-94e4-46f7-aeda-631520fae009", 0, "9815a6a3-ba77-49e5-942b-1efe4c653921", new DateTime(1982, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "stubbste@gmail.com", false, "Trevor", "Stubbs", false, null, null, null, null, null, false, "b6bdb1e0-f35c-4929-ae02-ad19975ea9c8", false, "1234", "stubbste@gmail.com", null });

            migrationBuilder.AddForeignKey(
                name: "FK_pageLikes_UserPages_UserPageID",
                table: "pageLikes",
                column: "UserPageID",
                principalTable: "UserPages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPageToPosts_UserPages_UserPageId",
                table: "UserPageToPosts",
                column: "UserPageId",
                principalTable: "UserPages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
