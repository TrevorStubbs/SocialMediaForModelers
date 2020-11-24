using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.DTOs
{
    public class PostCommentDTO : BaseDTO
    {
        public string Body { get; set; }        
        public LikeDTO CommentLikes { get; set; }
    }
}
