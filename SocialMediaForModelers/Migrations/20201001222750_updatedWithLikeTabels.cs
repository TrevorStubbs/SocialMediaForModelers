using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialMediaForModelers.Migrations
{
    public partial class updatedWithLikeTabels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentLike_PostComments_PostCommentID",
                table: "CommentLike");

            migrationBuilder.DropForeignKey(
                name: "FK_PageLike_UserPages_UserPageID",
                table: "PageLike");

            migrationBuilder.DropForeignKey(
                name: "FK_PostLike_UserPosts_UserPostID",
                table: "PostLike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostLike",
                table: "PostLike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PageLike",
                table: "PageLike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentLike",
                table: "CommentLike");

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "a90b7c0d-9588-47ba-abfa-35030dc6a110");

            migrationBuilder.RenameTable(
                name: "PostLike",
                newName: "PostLikes");

            migrationBuilder.RenameTable(
                name: "PageLike",
                newName: "pageLikes");

            migrationBuilder.RenameTable(
                name: "CommentLike",
                newName: "CommentLikes");

            migrationBuilder.RenameIndex(
                name: "IX_PostLike_UserPostID",
                table: "PostLikes",
                newName: "IX_PostLikes_UserPostID");

            migrationBuilder.RenameIndex(
                name: "IX_PageLike_UserPageID",
                table: "pageLikes",
                newName: "IX_pageLikes_UserPageID");

            migrationBuilder.RenameIndex(
                name: "IX_CommentLike_PostCommentID",
                table: "CommentLikes",
                newName: "IX_CommentLikes_PostCommentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostLikes",
                table: "PostLikes",
                columns: new[] { "PostId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_pageLikes",
                table: "pageLikes",
                columns: new[] { "PageId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentLikes",
                table: "CommentLikes",
                columns: new[] { "CommentId", "UserId" });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName", "UsersPageID" },
                values: new object[] { "fde21a89-8fe7-496c-8339-e742f9410c66", 0, "c2d186e1-f7d7-41ce-9fbd-a6c6f0805521", new DateTime(1982, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "stubbste@gmail.com", false, "Trevor", "Stubbs", false, null, null, null, null, null, false, "fb33837e-b667-4979-9002-0baf3507f8b7", false, "1234", "stubbste@gmail.com", null });

            migrationBuilder.AddForeignKey(
                name: "FK_CommentLikes_PostComments_PostCommentID",
                table: "CommentLikes",
                column: "PostCommentID",
                principalTable: "PostComments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_pageLikes_UserPages_UserPageID",
                table: "pageLikes",
                column: "UserPageID",
                principalTable: "UserPages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostLikes_UserPosts_UserPostID",
                table: "PostLikes",
                column: "UserPostID",
                principalTable: "UserPosts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentLikes_PostComments_PostCommentID",
                table: "CommentLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_pageLikes_UserPages_UserPageID",
                table: "pageLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_PostLikes_UserPosts_UserPostID",
                table: "PostLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostLikes",
                table: "PostLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pageLikes",
                table: "pageLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentLikes",
                table: "CommentLikes");

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "fde21a89-8fe7-496c-8339-e742f9410c66");

            migrationBuilder.RenameTable(
                name: "PostLikes",
                newName: "PostLike");

            migrationBuilder.RenameTable(
                name: "pageLikes",
                newName: "PageLike");

            migrationBuilder.RenameTable(
                name: "CommentLikes",
                newName: "CommentLike");

            migrationBuilder.RenameIndex(
                name: "IX_PostLikes_UserPostID",
                table: "PostLike",
                newName: "IX_PostLike_UserPostID");

            migrationBuilder.RenameIndex(
                name: "IX_pageLikes_UserPageID",
                table: "PageLike",
                newName: "IX_PageLike_UserPageID");

            migrationBuilder.RenameIndex(
                name: "IX_CommentLikes_PostCommentID",
                table: "CommentLike",
                newName: "IX_CommentLike_PostCommentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostLike",
                table: "PostLike",
                columns: new[] { "PostId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PageLike",
                table: "PageLike",
                columns: new[] { "PageId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentLike",
                table: "CommentLike",
                columns: new[] { "CommentId", "UserId" });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName", "UsersPageID" },
                values: new object[] { "a90b7c0d-9588-47ba-abfa-35030dc6a110", 0, "2939859c-8b27-46ce-b0f9-d5c116b8a7f9", new DateTime(1982, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "stubbste@gmail.com", false, "Trevor", "Stubbs", false, null, null, null, null, null, false, "b8da5b41-c5a9-4334-9b73-acd49645e974", false, "1234", "stubbste@gmail.com", null });

            migrationBuilder.AddForeignKey(
                name: "FK_CommentLike_PostComments_PostCommentID",
                table: "CommentLike",
                column: "PostCommentID",
                principalTable: "PostComments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PageLike_UserPages_UserPageID",
                table: "PageLike",
                column: "UserPageID",
                principalTable: "UserPages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostLike_UserPosts_UserPostID",
                table: "PostLike",
                column: "UserPostID",
                principalTable: "UserPosts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
