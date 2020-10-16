using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using SocialMediaForModelers.Model.Entities.JoinEntites;
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
        // TODO: add date created

        // Navigation properties
        public List<PostToComment> PostToComments { get; set; }
        public List<CommentLike> CommentLikes { get; set; }
    }
}
