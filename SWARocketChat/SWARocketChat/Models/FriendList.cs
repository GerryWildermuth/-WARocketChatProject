using System;
using System.ComponentModel.DataAnnotations;

namespace SWARocketChat.Models
{
    public class FriendList
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Username { get; set; }

        public ApplicationUser User { get; set; }
    }
}