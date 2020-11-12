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
    [AllowAnonymous]

    public class UserPostController : ControllerBase
    {
        private readonly IUserPost _userPost;

        public UserPostController(IUserPost userPost)
        {
            _userPost = userPost;
        }

        // POST: /UserPost
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
        public async Task<ActionResult<UserPostDTO>> PutUserPost(UserPostDTO updatePost, int postId)
        {
            var post = await _userPost.Update(updatePost, postId);

            if (post != null)
            {
                return post;
            }

            return BadRequest();
        }

        // DELETE: /UserPost/{postId}
        public async Task<IActionResult> DeletePost(int postId)
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

        // POST: /UserPost/{postId}/Like


        // GET: /UserPost/{postId}/Like

        // DELETE: /UserPost/{postId}/Like

        // POST: /UserPost/{postId}/{imageId}

        // DELETE: /UserPost/{postId}/{imageId}

        // POST: /UserPost/{postId}/{commentId}

        // DELETE: /UserPost/{postId}/{commentId}

    }
}
