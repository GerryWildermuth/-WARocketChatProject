using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SWARocketChat.Models
{
    public class UserRoomList
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ChatroomId { get; set; }
        public ICollection<Chatroom> Chatrooms { get; set; }
        [Required]
        public string UserId { get; set; }

        public int status { get; set; }
    }
}
