using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Controllers.ControllerSupport
{
    /// <summary>
    /// A list of methods to get specific claims from the provided ClaimsPrincipal
    /// </summary>
    public static class UserClaimsGetters
    {
        /// <summary>
        /// Gets the User's id from the JWToken claims
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string GetUserId(ClaimsPrincipal user)
        {
            // return user.Claims.FirstOrDefault(x => x.Type == "UserId").Value;
            return "1234"; // This is here for testing.
        }
    }
}
