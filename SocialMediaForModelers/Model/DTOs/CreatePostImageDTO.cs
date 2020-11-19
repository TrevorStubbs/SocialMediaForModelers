using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.DTOs
{
    public class CreatePostImageDTO : PostImageDTO
    {
        public string transferKey { get; set; }
    }
}
