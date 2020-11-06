using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.Entities.JoinEntites
{
    public class PostToImage
    {        
        public int PostId { get; set; }
        public int ImageId { get; set; }

        // Navigation properties
        public UserPost UserPost { get; set; }
        public PostImage PostImage { get; set; }
    }
}
