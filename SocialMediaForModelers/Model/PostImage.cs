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
        public int PostId { get; set; }
        public string ImageURI { get; set; } // Will need to change once S3 is setup
    }
}
