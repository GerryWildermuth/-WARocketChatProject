using System;
using System.Collections.Generic;

namespace SWARocketChat.Models
{
    public class ChatroomMembers
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public ICollection<User> Users { get; set; }
        public Guid UserId { get; set; }
        public bool WritingPrivilege { get; set; }
        //Priviliges to kick People(Owner Leader)
    }
}