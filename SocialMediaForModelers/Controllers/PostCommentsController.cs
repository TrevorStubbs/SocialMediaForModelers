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
    // ===================== TODO: Change to Restricted =============================
    [AllowAnonymous]
    public class PostCommentsController : ControllerBase
    {
        private readonly IPostComment _postComment;

        public PostCommentsController(IPostComment postComment)
        {
            _postComment = postComment;
        }

        // POST: /PostComment
        /// <summary>
        /// Creates a new PostComment and adds it to the database
        /// </summary>
        /// <param name="newComment">PostCommentDTO</param>
        /// <returns>Ok, if successful</returns>
        [HttpPost]
        public async Task<ActionResult<PostCommentDTO>> PostPostComment(PostCommentDTO newComment)
        {
            var comment = await _postComment.Create(newComment, UserClaimsGetters.GetUserId(User));

            if (comment != null)
            {
                return comment;
            }

            return BadRequest();
        }

        // GET: /PostComment
        /// <summary>
        /// Gets all comments from the database.
        /// </summary>
        /// <returns>A list of PostCommentDTOs</returns>
        [HttpGet]
        public async Task<ActionResult<List<PostCommentDTO>>> GetAllComments()
        {
            var comments = await _postComment.GetAllComments();

            if (comments != null)
            {
                return comments;
            }

            return BadRequest();
        }

        // Post: /PostComment/UserId
        /// <summary>
        /// POSTs a UserId to GET all the PostComments from the database of the current user.
        /// </summary>
        /// <param name="user">UserRequestDTO</param>
        /// <returns>List of PostCommentDTOs</returns>
        [HttpPost("UserId")]
        public async Task<ActionResult<List<PostCommentDTO>>> GetUsersPostComments(UserRequestDTO user)
        {
            var comments = await _postComment.GetAllUsersComments(user.UserId);

            if (comments != null)
            {
                return comments;
            }

            return BadRequest();
        }

        // GET: /PostComment/{postId}/post
        // ============ TODO: Re-evaluate the need for this route =============
        //[HttpGet("{postId}/UserPost")]
        //public async Task<ActionResult<List<PostCommentDTO>>> GetPostCommentsForUserPost(int postId)
        //{
        //    var comments = await _postComment.GetCommentsForAPost(postId);

        //    if (comments != null)
        //    {
        //        return comments;
        //    }

        //    return BadRequest();
        //}
        // =====================================================================

        // GET: /PostComment/{commentId}
        /// <summary>
        /// Gets a single PostComment.
        /// </summary>
        /// <param name="commentId">The comment's database id.</param>
        /// <returns>A PostCommentDTO</returns>
        [HttpGet("{commentId}")]
        public async Task<ActionResult<PostCommentDTO>> GetComment(int commentId)
        {
            var comment = await _postComment.GetASpecificComment(commentId);

            if (comment != null)
            {
                return comment;
            }

            return BadRequest();
        }

        // PUT: /PostComment/{commentId}
        /// <summary>
        /// Updates a PostComment.
        /// </summary>
        /// <param name="updateComment">The PostCommentDTO used to update the database.</param>
        /// <param name="commentId">The comment's database id.</param>
        /// <returns>The provided PostCommentDTO, if successful.</returns>
        [HttpPut("{commentId}")]
        public async Task<ActionResult<PostCommentDTO>> PutPostComment(PostCommentDTO updateComment, int commentId)
        {
            // Test to see if claim == post.UserId or policy is admin
            // if so allow the update
            // if not don't allow it

            if (commentId != updateComment.Id)
            {
                return BadRequest();
            }

            var comment = await _postComment.Update(updateComment, commentId);

            if (comment != null)
            {
                return comment;
            }

            return BadRequest();
        }

        // DELETE: /PostComment/{commentId}
        /// <summary>
        /// Deletes a PostComment from the database.
        /// </summary>
        /// <param name="commentId">The comment's database id.</param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{commentId}")]
        public async Task<IActionResult> DeletePostComment(int commentId)
        {
            // Test to see if claim == post.UserId or policy is admin
            // if so allow the delete
            // if not don't allow it

            try
            {
                await _postComment.Delete(commentId);

                return Ok();
            }
            catch (Exception e)
            {

                throw new Exception($"Delete action exception message: {e.Message}");
            }
        }

        // POST: /PostComment/{commentId}/Like
        /// <summary>
        /// Adds a like to the PostComment.
        /// </summary>
        /// <param name="commentId">The comment's database id.</param>
        /// <returns>IActionResult</returns>
        [HttpPost("{commentId}/Like")]
        public async Task<IActionResult> PostCommentLike(int commentId)
        {
            try
            {
                await _postComment.AddLikeToComment(commentId, UserClaimsGetters.GetUserId(User));

                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception($"Tried to add a like to a post: {e.Message}");
            }
        }

        // GET: /PostComment/{commentId}/Like
        /// <summary>
        /// Gets the like data for a comment.
        /// </summary>
        /// <param name="commentId">The comment's database id.</param>
        /// <returns>A LikeDTO, if successful.</returns>
        [HttpGet("{commentId}/Like")]
        public async Task<ActionResult<LikeDTO>> GetCommentLikes(int commentId)
        {
            var likeData = await _postComment.GetCommentsLikes(commentId, UserClaimsGetters.GetUserId(User));

            if (likeData != null)
            {
                return likeData;
            }

            return BadRequest();
        }

        // DELETE: /PostComment/{commentId}/Like
        /// <summary>
        /// Deletes a like from a PostComment.
        /// </summary>
        /// <param name="commentId">The comment's database id.</param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{commentId}/Like")]
        public async Task<IActionResult> DeleteCommentLike(int commentId)
        {
            try
            {
                await _postComment.DeleteALike(commentId, UserClaimsGetters.GetUserId(User));

                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception($"Cannot delete that like: {e.Message}");
            }
        }
    }
}
