using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model
{
    public class Post
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public string Caption{ get; set; }        
        public List<PostLike> PostLikes { get; set; }
        public List<PostComment> PostComments { get; set; }
        public List<PostImage> PostImages { get; set; }

    }
}
