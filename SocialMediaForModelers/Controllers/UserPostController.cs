using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialMediaForModelers.Controllers.ControllerSupport;
using SocialMediaForModelers.Model;
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
    [Authorize]

    public class UserPostController : ControllerBase
    {
        private readonly IUserPost _userPost;
        private readonly IPostComment _postComment;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserPostController(IUserPost userPost, IPostComment postComment, UserManager<ApplicationUser> userManager)
        {
            _userPost = userPost;
            _postComment = postComment;
            _userManager = userManager;
        }

        // POST: /UserPost
        /// <summary>
        /// Creates a new UsePost.
        /// </summary>
        /// <param name="newPost">UserPostDTO</param>
        /// <returns>Ok, if successful</returns>
        [HttpPost]
        public async Task<ActionResult<UserPostDTO>> PostUserPost(UserPostDTO newPost)
        {
            if(newPost.UserId == null)
            {
                newPost.UserId = UserClaimsGetters.GetUserId(User);
            }

            var post = await _userPost.Create(newPost);

            if (post != null)
            {
                return Ok();
            }

            return BadRequest();
        }

        // GET: /UserPost
        /// <summary>
        /// Get all UserPosts from the database.
        /// </summary>
        /// <returns>A List of UserPostDTOs</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPostDTO>>> GetAllPosts()
        {
            var posts = await _userPost.GetAllPosts();

            if (posts != null)
            {
                return posts;
            }

            return BadRequest();
        }

        // POST: /UserPost/UserId
        /// <summary>
        /// POSTs a UserId to GET all the UserPosts from the database of the current user.
        /// </summary>
        /// <param name="user">UserRequestDTO</param>
        /// <returns>List of UserPostDTOs</returns>
        [HttpPost("UserId")]
        public async Task<ActionResult<IEnumerable<UserPostDTO>>> GetUsersUserPosts(UserRequestDTO user)
        {
            var posts = await _userPost.GetAllUserPosts(user.UserId);

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
            // Test to see if claim == post.UserId or policy is admin
            // if so allow the update
            // if not don't allow it

            //if (postId != updatePost.Id)
            //{
            //    return BadRequest();
            //}

            var post = await _userPost.GetASpecificPost(postId);
            var usersRoles = UserClaimsGetters.GetUserRoles(User, _userManager);

            if (UserClaimsGetters.GetUserId(User) == post.UserId || usersRoles.Contains("Admin") || usersRoles.Contains("Owner"))
            {
                try
                {
                    var postUpdate = await _userPost.Update(updatePost, postId);

                    if (postUpdate != null)
                    {
                        return postUpdate;
                    }

                    return BadRequest();
                }
                catch (Exception e)
                {
                    throw new Exception($"Update error message: {e.Message}");
                }
            }

            throw new Exception("You are not authorized to Update that Post.");
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
            var post = await _userPost.GetASpecificPost(postId);
            var usersRoles = UserClaimsGetters.GetUserRoles(User, _userManager);

            if (UserClaimsGetters.GetUserId(User) == post.UserId || usersRoles.Contains("Admin") || usersRoles.Contains("Owner"))
            {
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

            throw new Exception("You are not authorized to Delete that Post.");
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
        /// Deletes a like from a UserPost
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
            var post = await _userPost.GetASpecificPost(postId);
            var usersRoles = UserClaimsGetters.GetUserRoles(User, _userManager);

            if (UserClaimsGetters.GetUserId(User) == post.UserId || usersRoles.Contains("Admin") || usersRoles.Contains("Owner"))
            {
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

            throw new Exception("You are not authorized to Add that Image to the Post.");
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
            var post = await _userPost.GetASpecificPost(postId);
            var usersRoles = UserClaimsGetters.GetUserRoles(User, _userManager);

            if (UserClaimsGetters.GetUserId(User) == post.UserId || usersRoles.Contains("Admin") || usersRoles.Contains("Owner"))
            {
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

            throw new Exception("You are not authorized to Delete that Image from the Post.");
        }

        // POST: /UserPost/{postId}/Comment/{commentId}
        /// <summary>
        /// Adds a comment to a post.
        /// </summary>
        /// <param name="postid">The post's database id.</param>
        /// <param name="commentId">The comment's database id.</param>
        /// <returns>IActionResult</returns>
        [HttpPost("{postId}/Comment/{commentId}")]
        public async Task<IActionResult> PostACommentToPost(int postId, int commentId)
        {
            try
            {
                await _userPost.AddACommentToAPost(postId, commentId);

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
        [HttpDelete("{postId}/Comment/{commentId}")]
        public async Task<IActionResult> DeleteACommentFromPost(int postId, int commentId)
        {
            var post = await _userPost.GetASpecificPost(postId);
            var comment = await _postComment.GetASpecificComment(commentId);
            var usersRoles = UserClaimsGetters.GetUserRoles(User, _userManager);

            if (UserClaimsGetters.GetUserId(User) == post.UserId || UserClaimsGetters.GetUserId(User) == comment.UserId || usersRoles.Contains("Admin") || usersRoles.Contains("Owner"))
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

            throw new Exception("You are not authorized to Delete that Post.");
        }
    }
}
