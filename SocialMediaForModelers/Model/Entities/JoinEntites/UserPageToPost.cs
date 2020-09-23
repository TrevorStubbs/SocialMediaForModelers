using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.Entities.JoinEntites
{
    public class UserPageToPost
    {
        public int UserPageId { get; set; }
        public int PostId { get; set; }

        // Navigation properties
        public UserPage UserPage { get; set; }
        public UserPost UserPost { get; set; }
    }
}
