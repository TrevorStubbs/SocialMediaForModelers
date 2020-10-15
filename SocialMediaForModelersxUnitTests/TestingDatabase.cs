using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SocialMediaForModelers.Data;
using SocialMediaForModelers.Model.Interfaces;
using SocialMediaForModelers.Model.Managers;
using System;
using Xunit;
using Microsoft.Data.Sqlite;

namespace SocialMediaForModelersxUnitTests
{
    public class Startup
    {
        public void ConfigurationServices(IServiceCollection service)
        {
            service.AddTransient<IPostComment, PostCommentManager>();
            service.AddTransient<IPostImage, PostImageManager>();
            service.AddTransient<IUserPost, UserPostManager>();
            service.AddTransient<IUserPage, UserPageManager>();
        }
    }
    public class TestingDatabase : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly SMModelersContext _db;
        protected readonly IPostComment _comment;
        protected readonly IPostImage _image;
        protected readonly IUserPost _post;

        public TestingDatabase()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new SMModelersContext(
                new DbContextOptionsBuilder<SMModelersContext>()
                .UseSqlite(_connection)
                .Options);

            _db.Database.EnsureCreated();

            _comment = new PostCommentManager(_db);

            _image = new PostImageManager(_db);

            _post = new UserPostManager(_db, _comment, _image);
        }

        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }
    }
}
