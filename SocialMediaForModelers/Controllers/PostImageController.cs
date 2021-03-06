﻿using Microsoft.AspNetCore.Authorization;
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
    public class PostImageController : ControllerBase
    {
        private readonly IPostImage _postImage;
        private readonly UserManager<ApplicationUser> _userManager;

        public PostImageController(IPostImage postImage, UserManager<ApplicationUser> userManager)
        {
            _postImage = postImage;
            _userManager = userManager;
        }

        // POST: /PostImage
        /// <summary>
        /// Creates a new image and adds it to the database. 
        /// </summary>
        /// <param name="newImage">A CreatePostImageDTO to build the database entry with.</param>
        /// <returns>Ok, if successful</returns>
        [HttpPost]
        public async Task<ActionResult<PostImageDTO>> PostPostImage(CreatePostImageDTO newImage)
        {
            var image = await _postImage.Create(newImage, UserClaimsGetters.GetUserId(User));

            if(image != null)
            {
                return Ok();
            }

            return BadRequest();
        }

        // GET: /PostImage
        /// <summary>
        /// Gets all Images from the database. 
        /// </summary>
        /// <returns>A list of PostImageDTOs</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostImageDTO>>> GetAllImages()
        {
            var images = await _postImage.GetAllImages();

            if(images != null)
            {
                return images;
            }

            return BadRequest();
        }

        // POST: /PostImage/UserId
        /// <summary>
        /// POSTs a UserId to GET all the PostImage from the database of the current user.
        /// </summary>
        /// <param name="user">UserRequestDTO</param>
        /// <returns>List of PostImageDTO</returns>
        [HttpPost("UserId")]
        public async Task<ActionResult<IEnumerable<PostImageDTO>>> GetUsersPostImages(UserRequestDTO user)
        {
            var images = await _postImage.GetAllUsersImages(user.UserId);

            if(images != null)
            {
                return images;
            }

            return BadRequest();
        }

        // GET: /PostImage/{imageId}
        /// <summary>
        /// Gets a single PostImage.
        /// </summary>
        /// <param name="commentId">The image's database id.</param>
        /// <returns>A PostImageDTO</returns>
        [HttpGet("{imageId}")]
        public async Task<ActionResult<PostImageDTO>> GetImage(int imageId)
        {
            var image = await _postImage.GetASpecificImage(imageId);

            if(image != null)
            {
                return image;
            }

            return BadRequest();
        }

        // PUT: /PostImage/{imageId}
        // ============ TODO: Re-evaluate the need for this route =============
        //[HttpPut("{imageId}")]
        //public async Task<ActionResult<PostImageDTO>> PutPostImage(PostImageDTO updateImage, int imageId)
        //{
        //    if(imageId != updateImage.Id)
        //    {
        //        return BadRequest();
        //    }

        //    var image = await _postImage.Update(updateImage, imageId);

        //    if(image != null)
        //    {
        //        return image;
        //    }

        //    return BadRequest();
        //}
        // ===========================================================================

        // DELETE: /PostImage/{imageId}
        /// <summary>
        /// Deletes a PostImage from the database.
        /// </summary>
        /// <param name="commentId">The image's database id.</param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{imageId}")]
        public async Task<IActionResult> DeletePostImage(int imageId)
        {
            // Test to see if claim == post.UserId or policy is admin
            // if so allow the delete
            // if not don't allow it
            var image = await _postImage.GetASpecificImage(imageId);
            var usersRoles = UserClaimsGetters.GetUserRoles(User, _userManager);

            if (UserClaimsGetters.GetUserId(User) == image.UserId || usersRoles.Contains("Admin") || usersRoles.Contains("Owner"))
            {
                try
                {
                    await _postImage.Delete(imageId);

                    return Ok();
                }
                catch (Exception e)
                {
                    throw new Exception($"Delete action exception message: {e.Message}");
                }
            }

            throw new Exception("You are not authorized to Delete that Image.");
        }
    }
}
