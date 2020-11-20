using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.DTOs
{
    public class CreatePostImageDTO : PostImageDTO
    {
        public string TransferKey { get; set; }
        public string ImageExtention { get; set; }
    }
}
