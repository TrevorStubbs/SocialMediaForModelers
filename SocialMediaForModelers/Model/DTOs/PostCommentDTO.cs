using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.DTOs
{
    public class PostCommentDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Body { get; set; }

        public List<LikeDTO> CommentLikes { get; set; }
    }
}
