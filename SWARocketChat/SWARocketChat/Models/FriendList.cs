using System;
using System.Collections.Generic;

namespace SWARocketChat.Models
{
    public class FriendList
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public virtual ICollection<ApplicationUser> User { get; set; }
        public ApplicationUser UserId { get; set; }
    }
}