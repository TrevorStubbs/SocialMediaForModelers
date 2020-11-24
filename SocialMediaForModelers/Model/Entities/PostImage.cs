using SocialMediaForModelers.Model.Entities;
using SocialMediaForModelers.Model.Entities.JoinEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model
{
    public class PostImage : EntityBase
    {
        public string CloudStorageKey { get; set; }

        // Navigation properties
        public List<PostToImage> PostToImages { get; set; }
    }
}
