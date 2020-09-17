using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model
{
    public class PostComment
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public string Body { get; set; }
        public List<CommentLike> CommentLikes { get; set; }
    }
}
