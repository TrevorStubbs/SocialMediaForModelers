using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.Entities.JoinEntites
{
    public class PostToComment
    {
        public int UserPageId { get; set; }
        public int CommentId { get; set; }

        // Navigation properties
    }
}
