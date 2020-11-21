using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.DTOs
{
    public abstract class BaseDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
