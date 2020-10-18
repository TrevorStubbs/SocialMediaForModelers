using Microsoft.AspNetCore.Identity;
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


    }
}
