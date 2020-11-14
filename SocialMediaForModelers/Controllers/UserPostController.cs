using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMediaForModelers.Controllers.ControllerSupport;
using SocialMediaForModelers.Model.DTOs;
using SocialMediaForModelers.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous] // Temporary - Change after testing

    public class UserPostController : ControllerBase
    {
        private readonly IUserPost _userPost;

        public UserPostController(IUserPost userPost)
        {
            _userPost = userPost;
        }

        // POST: /UserPost
        /// <summary>
        /// Creates a new UsePost.
        /// </summary>
        /// <param name="newPost">UserPostDTO</param>
        /// <returns>The UserPostDTO, if successful.</returns>
        [HttpPost]
        public async Task<ActionResult<UserPostDTO>> PostUserPost(UserPostDTO newPost)
        {
            var post = await _userPost.Create(newPost);

            if (post != null)
            {
                return post;
            }

            return BadRequest();
        }

        // GET: /UserPost
        /// <summary>
        /// Get all UserPosts from the database.
        /// </summary>
        /// <returns>A List of UserPostDTOs</returns>
        [HttpGet]
        public async Task<ActionResult<List<UserPostDTO>>> GetAllPosts()
        {
            var posts = await _userPost.GetAllPosts();

            if (posts != null)
            {
                return posts;
            }

            return BadRequest();
        }

        // GET: /UserPost/UserId
        /// <summary>
        /// Gets all the post owned by a user.
        /// </summary>
        /// <returns>A list of UserPostDTOs</returns>
        [HttpGet("UserId")]
        public async Task<ActionResult<List<UserPostDTO>>> GetUsersUserPosts()
        {
            var posts = await _userPost.GetAllUserPosts(UserClaimsGetters.GetUserId(User));

            if (posts != null)
            {
                return posts;
            }

            return BadRequest();
        }

        // GET: /UserPost/{postId}
        /// <summary>
        /// Gets a single UserPost.
        /// </summary>
        /// <param name="postId">The post's database id.</param>
        /// <returns>A UserPostDTO</returns>
        [HttpGet("{postId}")]
        public async Task<ActionResult<UserPostDTO>> GetAPost(int postId)
        {
            var post = await _userPost.GetASpecificPost(postId);

            if (post != null)
            {
                return post;
            }

            return BadRequest();
        }

        // PUT: /UserPost/{postId}
        /// <summary>
        /// Updates a UserPost.
        /// </summary>
        /// <param name="updatePost">The UserPostDTO used to update the database.</param>
        /// <param name="postId">The post's database id.</param>
        /// <returns>The provided UserPostDTO, if successful.</returns>
        [HttpPut("{postId}")]
        public async Task<ActionResult<UserPostDTO>> PutUserPost(UserPostDTO updatePost, int postId)
        {
            if (postId != updatePost.Id)
            {
                return BadRequest();
            }

            var post = await _userPost.Update(updatePost, postId);

            if (post != null)
            {
                return post;
            }

            return BadRequest();
        }

        // DELETE: /UserPost/{postId}
        /// <summary>
        /// Delete a UserPost.
        /// </summary>
        /// <param name="postId">The post's database id.</param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeletePost(int postId)
        {
            // Test to see if claim == post.UserId or policy is admin
            // if so allow the delete
            // if not don't allow it

            try
            {
                await _userPost.Delete(postId);

                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception($"Delete action exception message: {e.Message}");
            }
        }

        // POST: /UserPost/{postId}/Like
        /// <summary>
        /// Add a like to the UserPost.
        /// </summary>
        /// <param name="postId">The post's database id.</param>
        /// <returns>IActionResult</returns>
        [HttpPost("{postId}/Like")]
        public async Task<IActionResult> PostPostLike(int postId)
        {
            try
            {
                await _userPost.AddALikeToAPost(postId, UserClaimsGetters.GetUserId(User));

                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception($"Tried to add a like to a post: {e.Message}");
            }
        }

        // GET: /UserPost/{postId}/Like
        /// <summary>
        /// Get like data for a UserPost.
        /// </summary>
        /// <param name="postId">The post's database id.</param>
        /// <returns>A LikeDTO</returns>
        [HttpGet("{postId}/Like")]
        public async Task<ActionResult<LikeDTO>> GetPostLikes(int postId)
        {
            var likeData = await _userPost.GetPostLikes(postId, UserClaimsGetters.GetUserId(User));

            if (likeData != null)
            {
                return likeData;
            }

            return BadRequest();
        }

        // DELETE: /UserPost/{postId}/Like
        /// <summary>
        /// Delete's a like from a UserPost
        /// </summary>
        /// <param name="postId">The post's database id.</param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{postId}/Like")]
        public async Task<IActionResult> DeletePostLike(int postId)
        {            
            try
            {
                await _userPost.DeleteALike(postId, UserClaimsGetters.GetUserId(User));

                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception($"Cannot delete that like: {e.Message}");
            }
        }

        // POST: /UserPost/{postId}/Image/{imageId}
        /// <summary>
        /// Add an image to a UserPost.
        /// </summary>
        /// <param name="postId">The post's database id.</param>
        /// <param name="imageId">The image's database id.</param>
        /// <returns>IActionResult</returns>
        [HttpPost("{postId}/Image/{imageId}")]
        public async Task<IActionResult> PostAnImageToPost(int postId, int imageId)
        {
            // ====================== TODO: How are we going to deal with S3? =========================
            // Do we have this controller call the PostImage Controller?
            // Do we make the client do it?
            // Cant test till this is completed
            // ========================================================================================
            try
            {
                await _userPost.AddAnImageToAPost(postId, imageId);

                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception($"Cannot add the image to the post: {e.Message}");
            }
        }

        // DELETE: /UserPost/{postId}/Image/{imageId}
        /// <summary>
        /// Deletes an image from a UserPost
        /// </summary>
        /// <param name="postId">The post's database id.</param>
        /// <param name="imageid">The image's database id.</param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{postId}/Image/{imageId}")]
        public async Task<IActionResult> DeleteAnImageFromPost(int postId, int imageid)
        {
            // ====================== TODO: Same here how are we going to deal with S3 ===============   
            // Cant test till this is completed
            // =======================================================================================
            try
            {
                await _userPost.DeleteAnImageFromAPost(postId, imageid);

                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception($"Cannot delete the image from the post: {e.Message}");
            }
        }

        // POST: /UserPost/{postId}/Comment/{commentId}
        /// <summary>
        /// Adds a comment to a post.
        /// </summary>
        /// <param name="postid">The post's database id.</param>
        /// <param name="commentId">The comment's database id.</param>
        /// <returns>IActionResult</returns>
        [HttpPost("{postId}/Comment/{imageId}")]
        public async Task<IActionResult> PostACommentToPost(int postid, int commentId)
        {
            try
            {
                await _userPost.AddACommentToAPost(postid, commentId);

                return Ok();
            }
            catch (Exception e)
            {                
                throw new Exception($"Cannot add the comment to the post: {e.Message}");
            }
        }

        // DELETE: /UserPost/{postId}/Comment/{commentId}
        /// <summary>
        /// Deletes a PostComment from a UserPost.
        /// </summary>
        /// <param name="postId">The post's database id.</param>
        /// <param name="commentId">The comment's database id.</param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{postId}/Comment/{imageId}")]
        public async Task<IActionResult> DeleteACommentFromPost(int postId, int commentId)
        {
            try
            {
                await _userPost.DeleteACommentFromAPost(postId, commentId);

                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception($"Cannot delete the comment from the post: {e.Message}");
            }
        }

    }
}
