using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialMediaForModelers.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    ImageURI = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostImages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserPages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageName = table.Column<string>(nullable: true),
                    PageContent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserPosts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caption = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPosts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CommentLike",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    PostCommentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentLike", x => new { x.CommentId, x.UserId });
                    table.ForeignKey(
                        name: "FK_CommentLike_PostComments_PostCommentID",
                        column: x => x.PostCommentID,
                        principalTable: "PostComments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    UserId = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    UsersPageID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUsers_UserPages_UsersPageID",
                        column: x => x.UsersPageID,
                        principalTable: "UserPages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PageLike",
                columns: table => new
                {
                    PageId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    UserPageID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageLike", x => new { x.PageId, x.UserId });
                    table.ForeignKey(
                        name: "FK_PageLike_UserPages_UserPageID",
                        column: x => x.UserPageID,
                        principalTable: "UserPages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostLike",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    UserPostID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostLike", x => new { x.PostId, x.UserId });
                    table.ForeignKey(
                        name: "FK_PostLike_UserPosts_UserPostID",
                        column: x => x.UserPostID,
                        principalTable: "UserPosts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostToComments",
                columns: table => new
                {
                    UserPageId = table.Column<int>(nullable: false),
                    CommentId = table.Column<int>(nullable: false),
                    PostCommentID = table.Column<int>(nullable: true),
                    UserPostID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostToComments", x => new { x.UserPageId, x.CommentId });
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
                    PhotoId = table.Column<int>(nullable: false),
                    UserPostID = table.Column<int>(nullable: true),
                    PostImageID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostToImages", x => new { x.PostId, x.PhotoId });
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
                name: "UserPageToPosts",
                columns: table => new
                {
                    UserPageId = table.Column<int>(nullable: false),
                    PostId = table.Column<int>(nullable: false),
                    UserPostID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPageToPosts", x => new { x.UserPageId, x.PostId });
                    table.ForeignKey(
                        name: "FK_UserPageToPosts_UserPages_UserPageId",
                        column: x => x.UserPageId,
                        principalTable: "UserPages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPageToPosts_UserPosts_UserPostID",
                        column: x => x.UserPostID,
                        principalTable: "UserPosts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName", "UsersPageID" },
                values: new object[] { "886d49b7-456b-4a51-8d9e-6305c067588f", 0, "8173bfd1-88ec-4740-b816-f26397dc036e", new DateTime(1982, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Trevor", "Stubbs", false, null, null, null, null, null, false, "50002e06-d1a6-45e7-addf-305ba8223949", false, "1234", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_UsersPageID",
                table: "AppUsers",
                column: "UsersPageID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLike_PostCommentID",
                table: "CommentLike",
                column: "PostCommentID");

            migrationBuilder.CreateIndex(
                name: "IX_PageLike_UserPageID",
                table: "PageLike",
                column: "UserPageID");

            migrationBuilder.CreateIndex(
                name: "IX_PostLike_UserPostID",
                table: "PostLike",
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
                name: "IX_UserPageToPosts_UserPostID",
                table: "UserPageToPosts",
                column: "UserPostID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentLike");

            migrationBuilder.DropTable(
                name: "PageLike");

            migrationBuilder.DropTable(
                name: "PostLike");

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
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "UserPosts");

            migrationBuilder.DropTable(
                name: "UserPages");
        }
    }
}
