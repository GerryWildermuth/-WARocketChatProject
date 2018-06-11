using System;

namespace SWARocketChat.Models
{
    public class UserChatroomMember
    {
        public Guid ChatroomMembersId { get; set; }
        public ChatroomMembers ChatroomMembers { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
