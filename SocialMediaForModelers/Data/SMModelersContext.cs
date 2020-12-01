using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMediaForModelers.Model;
using SocialMediaForModelers.Model.Entities.JoinEntites;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Data
{
    public class SMModelersContext : IdentityDbContext<ApplicationUser>
    {
        public SMModelersContext(DbContextOptions<SMModelersContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var timeNow = DateTime.UtcNow;

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUserFriend>().HasKey(x => new { x.UserId, x.FriendId });

            // Join Tables
            modelBuilder.Entity<PostToComment>().HasKey(x => new { x.PostId, x.CommentId });
            modelBuilder.Entity<PostToImage>().HasKey(x => new { x.PostId, x.ImageId });
            modelBuilder.Entity<UserPageToPost>().HasKey(x => new { x.PageId, x.PostId });

            // Like Tables
            modelBuilder.Entity<CommentLike>().HasKey(x => new { x.CommentId, x.UserId });
            modelBuilder.Entity<PageLike>().HasKey(x => new { x.PageId, x.UserId });
            modelBuilder.Entity<PostLike>().HasKey(x => new { x.PostId, x.UserId });

            //modelBuilder.Entity<ApplicationUser>().HasData(
            //    new ApplicationUser
            //    {
            //        FirstName = "Trevor",
            //        LastName = "Stubbs",
            //        Email = "stubbste@gmail.com",
            //        UserName = "stubbste@gmail.com",
            //        DOB = new DateTime(1982, 6, 8)
            //    });

            modelBuilder.Entity<PostComment>().HasData(
                new PostComment
                {
                    ID = 1,
                    UserId = "1234",
                    Body = "I am a comment",
                    Created = timeNow,
                    Modified = timeNow
                });

            modelBuilder.Entity<PostImage>().HasData(
                new PostImage
                {
                    ID = 1,
                    UserId = "1234",
                    CloudStorageKey = "/Dog.png",
                    Created = timeNow,
                    Modified = timeNow
                });

            modelBuilder.Entity<UserPost>().HasData(
                new UserPost
                {
                    ID = 1,
                    UserId = "1234",
                    Caption = "This is my post",
                    Created = timeNow,
                    Modified = timeNow
                });

            modelBuilder.Entity<UserPage>().HasData(
                new UserPage
                {
                    ID = 1,
                    UserId = "1234",
                    PageName = "Seed Page",
                    PageContent = "I am I here",
                    Created = timeNow,
                    Modified = timeNow
                });

            // Join Table Seeds
            modelBuilder.Entity<PostToImage>().HasData(
                new PostToImage
                {
                    PostId = 1,
                    ImageId = 1
                });

            modelBuilder.Entity<PostToComment>().HasData(
                new PostToComment
                {
                    PostId = 1,
                    CommentId = 1
                });

            modelBuilder.Entity<UserPageToPost>().HasData(
                new UserPageToPost
                {
                    PageId = 1,
                    PostId = 1
                });
        }

        // Normal Tables
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<UserPage> UserPages { get; set; }
        public DbSet<UserPost> UserPosts { get; set; }
        // Join Tables
        public DbSet<AppUserFriend> UserFriends { get; set; }
        public DbSet<PostToComment> PostToComments { get; set; }
        public DbSet<PostToImage> PostToImages { get; set; }
        public DbSet<UserPageToPost> UserPageToPosts { get; set; }
        // Like Tables
        public DbSet<CommentLike> CommentLikes { get; set; }
        public DbSet<PageLike> PageLikes { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
    }
}
