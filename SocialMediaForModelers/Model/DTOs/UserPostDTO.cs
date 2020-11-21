using SocialMediaForModelers.Model.Entities.JoinEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.DTOs
{
    public class UserPostDTO : BaseDTO
    {
        public string Caption { get; set; }

        // Navigation properties
        public List<UserPageToPost> UserPageToPosts { get; set; }
        public List<LikeDTO> PostLikes { get; set; }
        public List<PostImageDTO> PostImages { get; set; }
        public List<PostCommentDTO> PostComments { get; set; }
    }
}
