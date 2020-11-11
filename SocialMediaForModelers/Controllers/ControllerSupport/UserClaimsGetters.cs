using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Controllers.ControllerSupport
{
    public static class UserClaimsGetters
    {
        public static string GetUserId(ClaimsPrincipal user)
        {
            // return user.Claims.FirstOrDefault(x => x.Type == "UserId").Value;
            return "1234"; // This is here for testing.
        }
    }
}
