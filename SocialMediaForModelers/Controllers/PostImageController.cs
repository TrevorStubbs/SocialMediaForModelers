using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        // GET: /PostImage

        // GET: /PostImage/UserId

        // GET: /PostImage/{imageId}

        // PUT: /PostImage/{imageId}

        // DELETE: /PostImage/{imageId}
    }
}
