using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SocialMediaForModelers.Controllers.ControllerSupport;
using SocialMediaForModelers.Data;
using SocialMediaForModelers.Model;
using SocialMediaForModelers.Model.DTOs;
using SocialMediaForModelers.Model.Interfaces;

namespace SocialMediaForModelers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // ===================== TODO: Change to Restricted =============================
    [AllowAnonymous] 
    public class UserPageController : ControllerBase
    {
        private readonly IUserPage _userPage;

        public UserPageController(IUserPage userPage)
        {
            _userPage = userPage;
        }

        // POST: /UserPage
        [HttpPost]
        public async Task<ActionResult<UserPageDTO>> PostUserPage(UserPageDTO newPage)
        {
            await _userPage.Create(newPage); // Might want to add the UserEmail or Id

            return Ok(); // Maybe reload the page
        }

        // GET: /UserPage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPageDTO>>> GetAllUserPages()
        {
            List<UserPageDTO> pages = await _userPage.GetAllPages();

            return pages;
        }

        // GET: /UserPage/UserId
        [HttpGet("UserId")]
        public async Task<ActionResult<IEnumerable<UserPageDTO>>> GetAllPagesForAUser()
        {
            var pages = await _userPage.GetAllPagesForAUser(UserClaimsGetters.GetUserId(User));

            return pages;
        }

        // GET: /UserPage/{PageId}
        [HttpGet("{pageId}")]
        public async Task<ActionResult<UserPageDTO>> GetAUserPage(int pageId)
        {
            var page = await _userPage.GetASpecificPage(pageId);

            return page;
        }
        
        // PUT: /UserPage/{PageId}
        [HttpPut("{pageId}")]
        public async Task<ActionResult<UserPageDTO>> UpdateAPage(UserPageDTO page, int pageId)
        {
            // Test to see if claim == page.UserId or policy is admin
            // if so allow the update
            // if not don't allow it

            if (pageId != page.Id)
            {
                return BadRequest();
            }

            var updatedPage = await _userPage.Update(page, pageId);

            return updatedPage;
        }

        // DELETE: /UserPage/{PageId}
        [HttpDelete("{pageId}")]
        public async Task<ActionResult<UserPage>> DeletePage(int pageId)
        {
            // Test to see if claim == page.UserId or policy is admin
            // if so allow the delete
            // if not don't allow it

            await _userPage.Delete(pageId);

            return Ok();
        }

        // POST: /UserPage/{PageId}/Like
        [HttpPost("{pageId}/Like")]
        public async Task<ActionResult<PageLike>> PostLike(int pageId)
        {
            await _userPage.AddALikeToAPage(pageId, UserClaimsGetters.GetUserId(User));

            return Ok(); // Maybe resend the 'like' data
        }

        
        // GET: /UserPage/{PageId}/Like
        [HttpGet("{pageId}/Like")]
        public async Task<ActionResult<LikeDTO>> GetLikes(int pageId)
        {
            var likeData = await _userPage.GetPageLikes(pageId, UserClaimsGetters.GetUserId(User));

            return likeData;
        }

        // DELETE: /UserPage/{PageId}/Like
        [HttpDelete("{pageId}/Like")]
        public async Task<IActionResult> DeleteLike(int pageId)
        {
            await _userPage.DeleteALike(pageId, UserClaimsGetters.GetUserId(User));

            return Ok();
        }

        // POST: /UserPage/{PageId}/UserPost/{PostId}
        [HttpPost("{pageId}/UserPost/{postId}")]
        public async Task<IActionResult> PostUserPost(int pageId, int postId)
        {
            await _userPage.AddAPostToAPage(pageId, postId);

            return Ok();
        }

        // DELETE: /UserPage/{PageId}/UserPost/{PostId}
        [HttpDelete("{pageId}/UserPost/{postId}")]
        public async Task<IActionResult> DeleteUserPost(int pageId, int postId)
        {
            await _userPage.DeleteAPostFromAPage(pageId, postId);

            return Ok();
        }
    }
}
