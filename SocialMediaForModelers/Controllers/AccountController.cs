using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SocialMediaForModelers.Model;
using SocialMediaForModelers.Model.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialMediaForModelers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _config;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }

        /// <summary>
        /// Route to Register a new user to the application
        /// </summary>
        /// <param name="newUser">A registerDTO provided by the client</param>
        /// <returns>IActionResult status</returns>
        // POST: api/Account/register
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDTO newUser)
        {
            ApplicationUser user = new ApplicationUser()
            {
                Email = newUser.Email,
                UserName = newUser.Email,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                DOB = Convert.ToDateTime(newUser.DOB)
            };

            var result = await _userManager.CreateAsync(user, newUser.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");

                await _signInManager.SignInAsync(user, false);

                return Ok();
            }

            return BadRequest("Registration Unsuccessful");
        }

        /// <summary>
        /// Route to let a client login a user
        /// </summary>
        /// <param name="userLogin">A login DTO</param>
        /// <returns>IActionResult status</returns>
        // POST: api/Account/Login
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDTO userLogin)
        {
            var result = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(userLogin.Email);

                var identityRole = await _userManager.GetRolesAsync(user);

                var token = CreateJwtToken(user, identityRole.ToList());

                return Ok(new
                {
                    jwt = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }

            return BadRequest("Invalid Attempt");
        }

        /// <summary>
        /// Route to change the role of a user. (Admins only)
        /// </summary>
        /// <param name="roleAssignment">AssingRole DTO</param>
        /// <returns>IActionResult status</returns>
        // POST: api/Assign/Role
        [HttpPost("Assign/Role")]
        [Authorize(Policy = "AdminPriv")]
        public async Task<IActionResult> AssingRoleToUser(AssignRoleDTO roleAssignment)
        {
            var user = await _userManager.FindByNameAsync(roleAssignment.Email);

            var result = await _userManager.AddToRoleAsync(user, roleAssignment.Role);

            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest("Was unable to assign the role");
        }

        /// <summary>
        /// Create a JWT token and feed it the required claims the app needs
        /// </summary>
        /// <param name="user">The User</param>
        /// <param name="roles">The Role of the user</param>
        /// <returns>The JWT Token with it's claims attatched</returns>
        private JwtSecurityToken CreateJwtToken(ApplicationUser user, List<string> roles)
        {
            var authClaims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
                new Claim("UserId", user.Id),
                new Claim("Email", user.Email)
            };

            foreach (var role in roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = MakeAuthenticationToken(authClaims);

            return token;
        }

        /// <summary>
        /// Create an Authentication Token
        /// </summary>
        /// <param name="claims">The Claims needed to build the token</param>
        /// <returns>The created token</returns>
        private JwtSecurityToken MakeAuthenticationToken(List<Claim> claims)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));

            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Issuer"],
                expires: DateTime.UtcNow.AddHours(24),
                claims: claims,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

    }
}
