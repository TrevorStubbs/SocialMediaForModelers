using SocialMediaForModelers.Model.Entities.JoinEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.DTOs
{
    public class UserPageDTO : BaseDTO
    {
        public string PageName { get; set; }
        public string PageContent { get; set; } // may need to be turned into a class
        public LikeDTO PageLikes { get; set; }

        // Navigation properties
        public List<UserPageToPost> PageToPost { get; set; }
    }
}
