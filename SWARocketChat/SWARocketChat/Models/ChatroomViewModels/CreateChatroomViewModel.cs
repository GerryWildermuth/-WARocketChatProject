using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SWARocketChat.Models.ChatroomViewModels
{
    public class CreateChatroomViewModel
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

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "ChatroomMembers")]
        public List<string> ChatroomMembers { get; set; }
    }
}
