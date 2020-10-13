﻿using SocialMediaForModelers.Model.Entities.JoinEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.DTOs
{
    public class UserPageDTO
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public string PageName { get; set; }
        public string PageContent { get; set; } // may need to be turned into a class

        // Navigation properties
        public List<LikeDTO> PageLikes { get; set; }
        public List<UserPageToPost> PageToPost { get; set; }
    }
}