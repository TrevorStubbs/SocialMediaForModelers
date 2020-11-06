using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialMediaForModelers.Migrations
{
    public partial class newInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostComments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostComments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PostImages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ImageURI = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostImages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserPosts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    Caption = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPosts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserFriends",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    FriendId = table.Column<string>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFriends", x => new { x.UserId, x.FriendId });
                    table.ForeignKey(
                        name: "FK_UserFriends_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    PageName = table.Column<string>(nullable: true),
                    PageContent = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserPages_AppUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommentLikes",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    PostCommentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentLikes", x => new { x.CommentId, x.UserId });
                    table.ForeignKey(
                        name: "FK_CommentLikes_PostComments_PostCommentID",
                        column: x => x.PostCommentID,
                        principalTable: "PostComments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostLikes",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    UserPostID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostLikes", x => new { x.PostId, x.UserId });
                    table.ForeignKey(
                        name: "FK_PostLikes_UserPosts_UserPostID",
                        column: x => x.UserPostID,
                        principalTable: "UserPosts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostToComments",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false),
                    CommentId = table.Column<int>(nullable: false),
                    PostCommentID = table.Column<int>(nullable: true),
                    UserPostID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostToComments", x => new { x.PostId, x.CommentId });
                    table.ForeignKey(
                        name: "FK_PostToComments_PostComments_PostCommentID",
                        column: x => x.PostCommentID,
                        principalTable: "PostComments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostToComments_UserPosts_UserPostID",
                        column: x => x.UserPostID,
                        principalTable: "UserPosts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostToImages",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false),
                    ImageId = table.Column<int>(nullable: false),
                    UserPostID = table.Column<int>(nullable: true),
                    PostImageID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostToImages", x => new { x.PostId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_PostToImages_PostImages_PostImageID",
                        column: x => x.PostImageID,
                        principalTable: "PostImages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostToImages_UserPosts_UserPostID",
                        column: x => x.UserPostID,
                        principalTable: "UserPosts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PageLikes",
                columns: table => new
                {
                    PageId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    UserPageID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageLikes", x => new { x.PageId, x.UserId });
                    table.ForeignKey(
                        name: "FK_PageLikes_UserPages_UserPageID",
                        column: x => x.UserPageID,
                        principalTable: "UserPages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPageToPosts",
                columns: table => new
                {
                    PageId = table.Column<int>(nullable: false),
                    PostId = table.Column<int>(nullable: false),
                    UserPageID = table.Column<int>(nullable: true),
                    UserPostID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPageToPosts", x => new { x.PageId, x.PostId });
                    table.ForeignKey(
                        name: "FK_UserPageToPosts_UserPages_UserPageID",
                        column: x => x.UserPageID,
                        principalTable: "UserPages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserPageToPosts_UserPosts_UserPostID",
                        column: x => x.UserPostID,
                        principalTable: "UserPosts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a048e477-a33f-40e1-8ce4-7aee1a12d6fa", 0, "ac9ee0f0-7e36-434f-b674-ec532e5c3f93", new DateTime(1982, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "stubbste@gmail.com", false, "Trevor", "Stubbs", false, null, null, null, null, null, false, "9fd039c3-bfe5-481e-8a3e-ca2c2ccff0db", false, "stubbste@gmail.com" });

            migrationBuilder.InsertData(
                table: "PostComments",
                columns: new[] { "ID", "Body", "UserId" },
                values: new object[] { 1, "I am a comment", "1234" });

            migrationBuilder.InsertData(
                table: "PostImages",
                columns: new[] { "ID", "ImageURI", "UserId" },
                values: new object[] { 1, "/Dog.png", "1234" });

            migrationBuilder.InsertData(
                table: "PostToComments",
                columns: new[] { "PostId", "CommentId", "PostCommentID", "UserPostID" },
                values: new object[] { 1, 1, null, null });

            migrationBuilder.InsertData(
                table: "PostToImages",
                columns: new[] { "PostId", "ImageId", "PostImageID", "UserPostID" },
                values: new object[] { 1, 1, null, null });

            migrationBuilder.InsertData(
                table: "UserPageToPosts",
                columns: new[] { "PageId", "PostId", "UserPageID", "UserPostID" },
                values: new object[] { 1, 1, null, null });

            migrationBuilder.InsertData(
                table: "UserPages",
                columns: new[] { "ID", "ApplicationUserId", "PageContent", "PageName", "UserId" },
                values: new object[] { 1, null, "I am I here", "Seed Page", "1234" });

            migrationBuilder.InsertData(
                table: "UserPosts",
                columns: new[] { "ID", "Caption", "UserId" },
                values: new object[] { 1, "This is my post", "1234" });

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_PostCommentID",
                table: "CommentLikes",
                column: "PostCommentID");

            migrationBuilder.CreateIndex(
                name: "IX_PageLikes_UserPageID",
                table: "PageLikes",
                column: "UserPageID");

            migrationBuilder.CreateIndex(
                name: "IX_PostLikes_UserPostID",
                table: "PostLikes",
                column: "UserPostID");

            migrationBuilder.CreateIndex(
                name: "IX_PostToComments_PostCommentID",
                table: "PostToComments",
                column: "PostCommentID");

            migrationBuilder.CreateIndex(
                name: "IX_PostToComments_UserPostID",
                table: "PostToComments",
                column: "UserPostID");

            migrationBuilder.CreateIndex(
                name: "IX_PostToImages_PostImageID",
                table: "PostToImages",
                column: "PostImageID");

            migrationBuilder.CreateIndex(
                name: "IX_PostToImages_UserPostID",
                table: "PostToImages",
                column: "UserPostID");

            migrationBuilder.CreateIndex(
                name: "IX_UserFriends_AppUserId",
                table: "UserFriends",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPages_ApplicationUserId",
                table: "UserPages",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPageToPosts_UserPageID",
                table: "UserPageToPosts",
                column: "UserPageID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPageToPosts_UserPostID",
                table: "UserPageToPosts",
                column: "UserPostID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentLikes");

            migrationBuilder.DropTable(
                name: "PageLikes");

            migrationBuilder.DropTable(
                name: "PostLikes");

            migrationBuilder.DropTable(
                name: "PostToComments");

            migrationBuilder.DropTable(
                name: "PostToImages");

            migrationBuilder.DropTable(
                name: "UserFriends");

            migrationBuilder.DropTable(
                name: "UserPageToPosts");

            migrationBuilder.DropTable(
                name: "PostComments");

            migrationBuilder.DropTable(
                name: "PostImages");

            migrationBuilder.DropTable(
                name: "UserPages");

            migrationBuilder.DropTable(
                name: "UserPosts");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
