using Microsoft.AspNetCore.Identity;

namespace SWARocketChat.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {

        public string UserImage { get; set; }
        public byte Status { get; set; }
        public ChatroomMembers ChatroomMembers { get; set; }
    }
}
