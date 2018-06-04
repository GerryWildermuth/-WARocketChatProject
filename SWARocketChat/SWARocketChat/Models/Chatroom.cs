using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SWARocketChat.Models
{
    public class Chatroom
    {
        public Chatroom()
        {
            {
                Messages = new HashSet<Message>();
            }
        }
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string ChatroomName { get; set; }
        public string ChatroomDesription { get; set; }
        public string ChatroomTopic { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public bool Private { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Today;
        public ChatroomMembers ChatroomMembers { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}