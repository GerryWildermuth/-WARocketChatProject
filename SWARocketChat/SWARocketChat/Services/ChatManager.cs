using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SWARocketChat.Data;
using SWARocketChat.Models;
using SWARocketChat.Models.ChatroomViewModels;

namespace SWARocketChat.Services
{
    public class ChatManager
    {
        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly ApplicationDbContext _dbContext;
        //public ChatManager(
        //    UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        //{
        //    _userManager = userManager;
        //    _dbContext = context;
        //}

        //public async void MessageCreate(ChannelViewModel model)
        //{
        //    var currentUser = await _userManager.FindByIdAsync(model.UserId);
        //    var chatroom = await _dbContext.Chatrooms.FirstOrDefaultAsync(c => c.Id == model.ChatroomId);
        //    var message = new Message
        //    {
        //        ChatroomId = model.ChatroomId,
        //        User = currentUser,
        //        MessageString = model.MessageString
        //    };
        //    if (chatroom != null)
        //    {
        //        _dbContext.Add(message);
        //        chatroom.Messages.Add(message);
        //        _dbContext.Update(chatroom);
        //        _dbContext.SaveChanges();
        //    }
        //}


    }
}
