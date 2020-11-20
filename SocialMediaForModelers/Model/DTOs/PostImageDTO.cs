using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.DTOs
{
    public class PostImageDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ImageURI { get; set; }
        // TODO: add date created       
    }
}
