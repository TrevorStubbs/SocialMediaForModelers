using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaForModelers.Model
{
    public class AppUserFriend
    {
        public string UserId { get; set; }
        public string FriendId { get; set; }

        // Navigation properties
        public ApplicationUser AppUser { get; set; }
        public ApplicationUser UserFriends { get; set; }
    }
}
