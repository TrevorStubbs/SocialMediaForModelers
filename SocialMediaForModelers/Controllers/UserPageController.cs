using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMediaForModelers.Data;
using SocialMediaForModelers.Model;
using SocialMediaForModelers.Model.Interfaces;

namespace SocialMediaForModelers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPageController : ControllerBase
    {
        private readonly IUserPage _userPage;

        public UserPageController(IUserPage userPage)
        {
            _userPage = userPage;
        }

        // POST: /UserPage

        // GET: /UserPage

        // GET: /UserPage/{UserId}

        // GET: /UserPage/{PageId}
        
        // PUT: /UserPage/{PageId}

        // DELETE: /UserPage/{PageId}

        // POST: /UserPage/{PageId}/Like/{UserId}
        
        // GET: /UserPage/{PageId}/Like/{UserId}
        
        // DELETE: /UserPage/{PageId}/Like/{UserId}
    }
}
