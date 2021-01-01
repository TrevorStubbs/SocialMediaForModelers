using SocialMediaForModelers.Model.Entities;
using SocialMediaForModelers.Model.Entities.JoinEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model
{
    public class UserPost : EntityBase
    {
        public string Caption{ get; set; }

        // Navigation properties
        public List<UserPageToPost> UserPageToPosts { get; set; }
        public List<PostLike> PostLikes { get; set; }
        public List<PostToImage> PostImages { get; set; }
        public List<PostToComment> PostComments { get; set; }
    }
}
