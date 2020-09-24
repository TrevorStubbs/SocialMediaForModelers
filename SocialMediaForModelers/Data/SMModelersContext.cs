using SocialMediaForModelers.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    UserId = "1234",
                    FirstName = "Trevor",
                    LastName = "Stubbs",
                    DOB = new DateTime(1982, 6, 8)
                });
        }
    }
}
