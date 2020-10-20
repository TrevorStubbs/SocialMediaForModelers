using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialMediaForModelers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.AppRoles
{
    public class RoleInitializer
    {
        private static readonly List<IdentityRole> Roles = new List<IdentityRole>()
        {
            new IdentityRole
            {
                Name = ApplicationRoles.Admin,
                NormalizedName = ApplicationRoles.Admin.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new IdentityRole
            {
                Name = ApplicationRoles.User,
                NormalizedName = ApplicationRoles.User.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            }
        };

        public static void SeedData(IServiceProvider serviceProvider, UserManager<ApplicationUser> users, IConfiguration _config)
        {
            using (var dbContext = new SMModelersContext(serviceProvider.GetRequiredService<DbContextOptions<SMModelersContext>>()))
            {
                dbContext.Database.EnsureCreated();
                AddRoles(dbContext);
                SeedUsers(users, _config);
            }
        }

        public static void SeedUsers(UserManager<ApplicationUser> userManager, IConfiguration _config)
        {
            if (userManager.FindByEmailAsync(_config["AdminEmail"]).Result == null)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = _config["AdminEmail"],
                    Email = _config["AdminEmail"],
                    FirstName = "Trevor",
                    LastName = "Stubbs",
                    DOB = new DateTime(1982, 6, 8)
                };

                IdentityResult result = userManager.CreateAsync(user, _config["AdminPassword"]).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, ApplicationRoles.Admin).Wait();
                }
            }

            if (userManager.FindByEmailAsync(_config["UserEmail"]).Result == null)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = _config["UserEmail"],
                    Email = _config["UserEmail"],
                    FirstName = "Sharn",
                    LastName = "Stryker",
                    DOB = new DateTime(2001, 10, 15)
                };

                IdentityResult result = userManager.CreateAsync(user, _config["UserEmail"]).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, ApplicationRoles.User).Wait();
                }
            }
        }

        private static void AddRoles(SMModelersContext context)
        {
            if (context.Roles.Any())
                return;

            foreach (var role in Roles)
            {
                context.Roles.Add(role);
                context.SaveChanges();
            }
        }
    }
}
