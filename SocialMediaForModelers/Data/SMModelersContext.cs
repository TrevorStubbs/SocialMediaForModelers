using Microsoft.EntityFrameworkCore;
using SocialMediaForModelers.Model;
using SocialMediaForModelers.Model.Entities.JoinEntites;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Data
{
    public class SMModelersContext : DbContext
    {
        public SMModelersContext(DbContextOptions<SMModelersContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUserFriend>().HasKey(x => new { x.UserId, x.FriendId });

            modelBuilder.Entity<PostToComment>().HasKey(x => new { x.UserPageId, x.CommentId });
            modelBuilder.Entity<PostToImage>().HasKey(x => new { x.PostId, x.PhotoId });
            modelBuilder.Entity<UserPageToPost>().HasKey(x => new { x.UserPageId, x.PostId });
            modelBuilder.Entity<CommentLike>().HasKey(x => new { x.CommentId, x.UserId });
            modelBuilder.Entity<PageLike>().HasKey(x => new { x.PageId, x.UserId });
            modelBuilder.Entity<PostLike>().HasKey(x => new { x.PostId, x.UserId });

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    UserId = "1234",
                    FirstName = "Trevor",
                    LastName = "Stubbs",
                    Email = "stubbste@gmail.com",
                    UserName = "stubbste@gmail.com",
                    DOB = new DateTime(1982, 6, 8)
                });
        }

        // Normal Tables
        public DbSet<ApplicationUser> AppUsers { get; set; }
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
        public DbSet<PageLike> pageLikes { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
    }
}
