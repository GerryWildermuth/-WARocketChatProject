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

        public User User { get; set; }
    }
}