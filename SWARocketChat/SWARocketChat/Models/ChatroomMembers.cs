using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SWARocketChat.Models
{
    public class ChatroomMembers
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public virtual IList<ApplicationUser> Users { get; set; }
        public bool WritingPrivilege { get; set; }
        //Priviliges to kick People(Owner Leader)
        public Chatroom Chatroom { get; set; }
        [Required]
        public Guid ChatroomId { get; set; }
    }
}