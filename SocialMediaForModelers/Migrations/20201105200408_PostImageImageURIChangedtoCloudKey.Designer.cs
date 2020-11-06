﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialMediaForModelers.Data;

namespace SocialMediaForModelers.Migrations
{
    [DbContext(typeof(SMModelersContext))]
    [Migration("20201105200408_PostImageImageURIChangedtoCloudKey")]
    partial class PostImageImageURIChangedtoCloudKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SocialMediaForModelers.Model.AppUserFriend", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FriendId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "FriendId");

                    b.HasIndex("AppUserId");

                    b.ToTable("UserFriends");
                });

            modelBuilder.Entity("SocialMediaForModelers.Model.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "8fe8247e-2345-4fca-8412-489d2ccdcaee",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4034e20d-4f45-4ae4-9c86-2d8aced96443",
                            DOB = new DateTime(1982, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "stubbste@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Trevor",
                            LastName = "Stubbs",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9e2ba19d-ef5b-4057-9a4a-79300ea1bd7c",
                            TwoFactorEnabled = false,
                            UserName = "stubbste@gmail.com"
                        });
                });

            modelBuilder.Entity("SocialMediaForModelers.Model.CommentLike", b =>
                {
                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("PostCommentID")
                        .HasColumnType("int");

                    b.HasKey("CommentId", "UserId");

                    b.HasIndex("PostCommentID");

                    b.ToTable("CommentLikes");
                });

            modelBuilder.Entity("SocialMediaForModelers.Model.Entities.JoinEntites.PostToComment", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<int?>("PostCommentID")
                        .HasColumnType("int");

                    b.Property<int?>("UserPostID")
                        .HasColumnType("int");

                    b.HasKey("PostId", "CommentId");

                    b.HasIndex("PostCommentID");

                    b.HasIndex("UserPostID");

                    b.ToTable("PostToComments");

                    b.HasData(
                        new
                        {
                            PostId = 1,
                            CommentId = 1
                        });
                });

            modelBuilder.Entity("SocialMediaForModelers.Model.Entities.JoinEntites.PostToImage", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.Property<int?>("PostImageID")
                        .HasColumnType("int");

                    b.Property<int?>("UserPostID")
                        .HasColumnType("int");

                    b.HasKey("PostId", "ImageId");

                    b.HasIndex("PostImageID");

                    b.HasIndex("UserPostID");

                    b.ToTable("PostToImages");

                    b.HasData(
                        new
                        {
                            PostId = 1,
                            ImageId = 1
                        });
                });

            modelBuilder.Entity("SocialMediaForModelers.Model.Entities.JoinEntites.UserPageToPost", b =>
                {
                    b.Property<int>("PageId")
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int?>("UserPageID")
                        .HasColumnType("int");

                    b.Property<int?>("UserPostID")
                        .HasColumnType("int");

                    b.HasKey("PageId", "PostId");

                    b.HasIndex("UserPageID");

                    b.HasIndex("UserPostID");

                    b.ToTable("UserPageToPosts");

                    b.HasData(
                        new
                        {
                            PageId = 1,
                            PostId = 1
                        });
                });

            modelBuilder.Entity("SocialMediaForModelers.Model.PageLike", b =>
                {
                    b.Property<int>("PageId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("UserPageID")
                        .HasColumnType("int");

                    b.HasKey("PageId", "UserId");

                    b.HasIndex("UserPageID");

                    b.ToTable("PageLikes");
                });

            modelBuilder.Entity("SocialMediaForModelers.Model.PostComment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("PostComments");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Body = "I am a comment",
                            UserId = "1234"
                        });
                });

            modelBuilder.Entity("SocialMediaForModelers.Model.PostImage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CloudStorageKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("PostImages");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CloudStorageKey = "/Dog.png",
                            UserId = "1234"
                        });
                });

            modelBuilder.Entity("SocialMediaForModelers.Model.PostLike", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("UserPostID")
                        .HasColumnType("int");

                    b.HasKey("PostId", "UserId");

                    b.HasIndex("UserPostID");

                    b.ToTable("PostLikes");
                });

            modelBuilder.Entity("SocialMediaForModelers.Model.UserPage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PageContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("UserPages");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            PageContent = "I am I here",
                            PageName = "Seed Page",
                            UserId = "1234"
                        });
                });

            modelBuilder.Entity("SocialMediaForModelers.Model.UserPost", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("UserPosts");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Caption = "This is my post",
                            UserId = "1234"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SocialMediaForModelers.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SocialMediaForModelers.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialMediaForModelers.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SocialMediaForModelers.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SocialMediaForModelers.Model.AppUserFriend", b =>
                {
                    b.HasOne("SocialMediaForModelers.Model.ApplicationUser", "AppUser")
                        .WithMany("UserFriends")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("SocialMediaForModelers.Model.CommentLike", b =>
                {
                    b.HasOne("SocialMediaForModelers.Model.PostComment", "PostComment")
                        .WithMany("CommentLikes")
                        .HasForeignKey("PostCommentID");
                });

            modelBuilder.Entity("SocialMediaForModelers.Model.Entities.JoinEntites.PostToComment", b =>
                {
                    b.HasOne("SocialMediaForModelers.Model.PostComment", null)
                        .WithMany("PostToComments")
                        .HasForeignKey("PostCommentID");

                    b.HasOne("SocialMediaForModelers.Model.UserPost", null)
                        .WithMany("PostComments")
                        .HasForeignKey("UserPostID");
                });

            modelBuilder.Entity("SocialMediaForModelers.Model.Entities.JoinEntites.PostToImage", b =>
                {
                    b.HasOne("SocialMediaForModelers.Model.PostImage", "PostImage")
                        .WithMany("PostToImages")
                        .HasForeignKey("PostImageID");

                    b.HasOne("SocialMediaForModelers.Model.UserPost", "UserPost")
                        .WithMany("PostImages")
                        .HasForeignKey("UserPostID");
                });

            modelBuilder.Entity("SocialMediaForModelers.Model.Entities.JoinEntites.UserPageToPost", b =>
                {
                    b.HasOne("SocialMediaForModelers.Model.UserPage", "UserPage")
                        .WithMany("PageToPost")
                        .HasForeignKey("UserPageID");

                    b.HasOne("SocialMediaForModelers.Model.UserPost", "UserPost")
                        .WithMany("UserPageToPosts")
                        .HasForeignKey("UserPostID");
                });

            modelBuilder.Entity("SocialMediaForModelers.Model.PageLike", b =>
                {
                    b.HasOne("SocialMediaForModelers.Model.UserPage", "UserPage")
                        .WithMany("PageLikes")
                        .HasForeignKey("UserPageID");
                });

            modelBuilder.Entity("SocialMediaForModelers.Model.PostLike", b =>
                {
                    b.HasOne("SocialMediaForModelers.Model.UserPost", "UserPost")
                        .WithMany("PostLikes")
                        .HasForeignKey("UserPostID");
                });

            modelBuilder.Entity("SocialMediaForModelers.Model.UserPage", b =>
                {
                    b.HasOne("SocialMediaForModelers.Model.ApplicationUser", null)
                        .WithMany("UsersPage")
                        .HasForeignKey("ApplicationUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
