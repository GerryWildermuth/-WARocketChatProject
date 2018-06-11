using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SWARocketChat.Models
{
    public class UserRoomList
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ChatroomId { get; set; }
        public Chatroom Chatroom { get; set; }
        [Required]
        public string ApplicationUserId { get; set; }

        public int ChatroomStatus { get; set; }
    }
}
