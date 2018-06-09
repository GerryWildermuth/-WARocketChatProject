using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SWARocketChat.Models.ChatroomViewModels
{
    public class ChannelViewModel
    {
        [Required]
        [Display(Name = "MessageString")]
        public string MessageString { get; set; }
        public Chatroom Chatroom { get; set; }
        [Required]
        public Guid ChatroomId { get; set; }
        [Display(Name = "ChatroomMembers")]
        public List<string> ChatroomMembers { get; set; }
    }
}
