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
    public class PostImageController : ControllerBase
    {
        private readonly IPostImage _postImage;

        public PostImageController(IPostImage postImage)
        {
            _postImage = postImage;
        }

        // POST: /PostImage
        [HttpPost]
        public async Task<ActionResult<PostImageDTO>> PostPostImage(CreatePostImageDTO newImage)
        {
            var image = await _postImage.Create(newImage, UserClaimsGetters.GetUserId(User));

            if(image != null)
            {
                return image;
            }

            return BadRequest();
        }

        // GET: /PostImage
        [HttpGet]
        public async Task<ActionResult<List<PostImageDTO>>> GetAllImages()
        {
            var images = await _postImage.GetAllImages();

            if(images != null)
            {
                return images;
            }

            return BadRequest();
        }

        // GET: /PostImage/UserId
        [HttpGet("UserId")]
        public async Task<ActionResult<List<PostImageDTO>>> GetUsersPostImages()
        {
            var images = await _postImage.GetAllUsersImages(UserClaimsGetters.GetUserId(User));

            if(images != null)
            {
                return images;
            }

            return BadRequest();
        }

        // GET: /PostImage/{imageId}
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
        [HttpPut("{imageId}")]
        public async Task<ActionResult<PostImageDTO>> PutPostImage(PostImageDTO updateImage, int imageId)
        {
            if(imageId != updateImage.Id)
            {
                return BadRequest();
            }

            var image = await _postImage.Update(updateImage, imageId);

            if(image != null)
            {
                return image;
            }

            return BadRequest();
        }

        // DELETE: /PostImage/{imageId}
        [HttpDelete("{imageId}")]
        public async Task<IActionResult> DeletePostImage(int imageId)
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
    }
}
