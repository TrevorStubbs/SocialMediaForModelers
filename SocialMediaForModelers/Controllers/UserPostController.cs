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
    [AllowAnonymous]

    public class UserPostController : ControllerBase
    {
        private readonly IUserPost _userPost;

        public UserPostController(IUserPost userPost)
        {
            _userPost = userPost;
        }

        // POST: /UserPost

        // GET: /UserPost

        // GET: /UserPost/UserId

        // GET: /UserPost/{postId}

        // PUT: /UserPost/{postId}

        // DELETE: /UserPost/{postId}

        // POST: /UserPost/{postId}/Like

        // GET: /UserPost/{postId}/Like

        // DELETE: /UserPost/{postId}/Like

        // POST: /UserPost/{postId}/{imageId}

        // DELETE: /UserPost/{postId}/{imageId}

        // POST: /UserPost/{postId}/{commentId}
        
        // DELETE: /UserPost/{postId}/{commentId}

    }
}
