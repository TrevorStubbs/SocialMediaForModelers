using SocialMediaForModelers.Model.Entities.JoinEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model
{
    public class PostImage
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public string ImageURI { get; set; } // Will need to change once S3 is setup
        // TODO: add date created

        // Navigation properties
        public List<PostToImage> PostToImages { get; set; }
    }
}
