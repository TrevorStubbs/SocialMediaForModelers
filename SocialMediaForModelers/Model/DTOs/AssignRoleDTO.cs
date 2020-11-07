using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model.DTOs
{
    public class AssignRoleDTO
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
