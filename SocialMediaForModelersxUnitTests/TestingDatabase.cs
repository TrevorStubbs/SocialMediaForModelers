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
        }
    }
    public class TestingDatabase : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly SMModelersContext _db;

        public TestingDatabase()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new SMModelersContext(
                new DbContextOptionsBuilder<SMModelersContext>()
                .UseSqlite(_connection)
                .Options);

            _db.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }
    }
}
