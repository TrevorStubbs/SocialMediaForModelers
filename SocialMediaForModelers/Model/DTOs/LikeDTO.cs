using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.DTOs
{
    public class LikeDTO
    {
        public int NumberOfLikes { get; set; }
        public bool UserLiked { get; set; }
    }
}
