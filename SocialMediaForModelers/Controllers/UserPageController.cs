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
        /// <summary>
        /// Creates a new UserPage in the database.
        /// </summary>
        /// <param name="newPage">Client provided UserPageDTO</param>
        /// <returns>Ok, if successful</returns>
        [HttpPost]
        public async Task<ActionResult<UserPageDTO>> PostUserPage(UserPageDTO newPage)
        {
            var page = await _userPage.Create(newPage); // Might want to add the UserEmail or Id

            if (page != null)
            {
                return Ok();
            }

            return BadRequest(); // Maybe reload the page
        }

        // GET: /UserPage
        /// <summary>
        /// Gets all of the UserPages from the database and returns a list of UserPageDTOs to the client.
        /// </summary>
        /// <returns>List of UserPageDTOs</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPageDTO>>> GetAllUserPages()
        {
            List<UserPageDTO> pages = await _userPage.GetAllPages();

            if (pages != null)
            {
                return pages;
            }

            return BadRequest();
        }

        // POST: /UserPage/UserId
        /// <summary>
        /// POSTs a UserId to GET all the UserPage from the database of the current user.
        /// </summary>
        /// <param name="user">UserRequestDTO</param>
        /// <returns>List of UserPages</returns>
        [HttpPost("UserId")]
        public async Task<ActionResult<IEnumerable<UserPageDTO>>> GetAllPagesForAUser(UserRequestDTO user)
        {
            var pages = await _userPage.GetAllPagesForAUser(user.UserId);

            if (pages != null)
            {
                return pages;
            }

            return BadRequest();
        }

        // GET: /UserPage/{PageId}
        /// <summary>
        /// Gets a specific page from the database and returns a UserPageDTO to the client.
        /// </summary>
        /// <param name="pageId">The page's database id.</param>
        /// <returns>A single UserPageDTO</returns>
        [HttpGet("{pageId}")]
        public async Task<ActionResult<UserPageDTO>> GetAUserPage(int pageId)
        {
            var page = await _userPage.GetASpecificPage(pageId);

            if (page != null)
            {
                return page;
            }

            return BadRequest();
        }

        // PUT: /UserPage/{PageId}
        /// <summary>
        /// Updates a UserPage.
        /// </summary>
        /// <param name="page">A UserPageDTO with the updated information.</param>
        /// <param name="pageId">The page's database id</param>
        /// <returns>The UserPageDTO, if action successful</returns>
        [HttpPut("{pageId}")]
        public async Task<ActionResult<UserPageDTO>> PutAPage(UserPageDTO page, int pageId)
        {
            // Test to see if claim == page.UserId or policy is admin
            // if so allow the update
            // if not don't allow it

            var updatedPage = await _userPage.Update(page, pageId);

            return updatedPage;
        }

        // DELETE: /UserPage/{PageId}
        /// <summary>
        /// Delete's a UserPage from the database.
        /// </summary>
        /// <param name="pageId">The page's database id.</param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{pageId}")]
        public async Task<IActionResult> DeletePage(int pageId)
        {
            // Test to see if claim == page.UserId or policy is admin
            // if so allow the delete
            // if not don't allow it

            try
            {
                await _userPage.Delete(pageId);

                return Ok();
            }
            catch (Exception e)
            {

                throw new Exception($"Delete action exception message: {e.Message}"
                    );
            }
        }

        // POST: /UserPage/{PageId}/Like
        /// <summary>
        /// Adds a Like to a UserPage.
        /// </summary>
        /// <param name="pageId">The page's database id.</param>
        /// <returns>IActionResult</returns>
        [HttpPost("{pageId}/Like")]
        public async Task<IActionResult> PostPageLike(int pageId)
        {
            try
            {
                await _userPage.AddALikeToAPage(pageId, UserClaimsGetters.GetUserId(User));

                return Ok(); // Maybe resend the 'like' data
            }
            catch (Exception e)
            {

                throw new Exception($"Tried to add a like to a page: {e.Message}");
            }
        }


        // GET: /UserPage/{PageId}/Like
        /// <summary>
        /// Gets a LikeDTO for the page.
        /// </summary>
        /// <param name="pageId">The page's database id.</param>
        /// <returns>A LikeDTO object</returns>
        [HttpGet("{pageId}/Like")]
        public async Task<ActionResult<LikeDTO>> GetPageLikes(int pageId)
        {
            var likeData = await _userPage.GetPageLikes(pageId, UserClaimsGetters.GetUserId(User));

            if (likeData != null)
            {
                return likeData;
            }

            return BadRequest();
        }

        // DELETE: /UserPage/{PageId}/Like
        /// <summary>
        /// Delete's a like from a UserPage.
        /// </summary>
        /// <param name="pageId">The page's database id.</param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{pageId}/Like")]
        public async Task<IActionResult> DeletePageLike(int pageId)
        {
            // Test to see if claim == post.UserId or policy is admin
            // if so allow the delete
            // if not don't allow it

            try
            {
                await _userPage.DeleteALike(pageId, UserClaimsGetters.GetUserId(User));

                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception($"Cannot delete that like: {e.Message}");
            }
        }

        // POST: /UserPage/{PageId}/UserPost/{PostId}
        /// <summary>
        /// Adds a UserPost to a UserPage.
        /// </summary>
        /// <param name="pageId">The page's database id.</param>
        /// <param name="postId">The post's database id.</param>
        /// <returns></returns>
        [HttpPost("{pageId}/UserPost/{postId}")]
        public async Task<IActionResult> PostUserPostToPage(int pageId, int postId)
        {
            try
            {
                await _userPage.AddAPostToAPage(pageId, postId);

                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception($"Cannot add that post to the page: {e.Message}");
            }
        }

        // DELETE: /UserPage/{PageId}/UserPost/{PostId}
        /// <summary>
        /// Delete's a UserPost from a UserPage.
        /// </summary>
        /// <param name="pageId">The page's database id.</param>
        /// <param name="postId">The post's database id.</param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{pageId}/UserPost/{postId}")]
        public async Task<IActionResult> DeleteUserPostFromPage(int pageId, int postId)
        {
            try
            {
                await _userPage.DeleteAPostFromAPage(pageId, postId);

                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception($"Cannot delete that post from the page: {e.Message}");
            }
        }
    }
}
