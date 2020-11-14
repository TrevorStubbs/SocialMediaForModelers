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
    public class PostCommentsController : ControllerBase
    {
        private readonly IPostComment _postComment;

        public PostCommentsController(IPostComment postComment)
        {
            _postComment = postComment;
        }

        // POST: /PostComment

        // GET: /PostComment

        // GET: /PostComment/UserId

        // GET: /PostComment/{postId}/post

        // GET: /PostComment/{commentId}

        // PUT: /PostComment/{commentId}

        // DELETE: /PostComment/{commentId}

    }
}
