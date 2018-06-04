using System;
using System.ComponentModel.DataAnnotations;

namespace SWARocketChat.Models
{
    public class Message
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string MessageString { get; set; }
        [Required]
        public DateTime MessageTime { get; set; } = DateTime.Now;

        public ApplicationUser User { get; set; }
        public Chatroom Chatroom { get; set; }
        [Required]
        public Guid ChatroomId { get; set; }
    }
}