using System;
using System.ComponentModel.DataAnnotations;

namespace SWARocketChat.Models.ChatroomViewModels
{
    public class ChannelViewModel
    {
        [Required]
        [Display(Name = "ChatroomName")]
        public string ChatroomName { get; set; }
        [Display(Name = "Private")]
        public bool Private { get; set; }

        [Display(Name = "ChatroomDesription")]
        public string ChatroomDesription { get; set; }

        [Display(Name = "ChatroomTopic")]
        public string ChatroomTopic { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "ChatroomMembers")]
        public ChatroomMembers ChatroomMembers { get; set; }

        [Display(Name = "CreationDate")]
        public DateTime CreationDate { get; set; } = DateTime.Today;
        [Display(Name = "MessageString")]
        public string MessageString { get; set; }
        [Display(Name = "MessageTime")]
        public DateTime MessageTime { get; set; } = DateTime.Now;
        public ApplicationUser User { get; set; }
        public Guid ChatroomId { get; set; }
        public Guid MessageId { get; set; }
        public Chatroom Chatroom { get; set; }
        public Message Message { get; set; }
    }
}
