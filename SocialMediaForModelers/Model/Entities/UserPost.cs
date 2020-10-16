﻿using SocialMediaForModelers.Model.Entities.JoinEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model
{
    public class UserPost
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public string Caption{ get; set; }
        // TODO: add date created

        // Navigation properties
        public List<UserPageToPost> UserPageToPosts { get; set; }
        public List<PostLike> PostLikes { get; set; }
        public List<PostToImage> PostImages { get; set; }
        public List<PostToComment> PostComments { get; set; }
    }
}
