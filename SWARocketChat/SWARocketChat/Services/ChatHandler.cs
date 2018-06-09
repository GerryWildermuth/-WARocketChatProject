using System;
using System.Dynamic;
using System.Threading.Tasks;
using SWARocketChat.Controllers;
using SWARocketChat.Models;
using SWARocketChat.Models.ChatroomViewModels;
using WebSocketManager;

namespace SWARocketChat.Services
{
    public class ChatHandler: WebSocketHandler
    {
        private readonly ChatManager _chatManager;
        public ChatHandler(WebSocketConnectionManager webSocketConnectionManager, ChatManager chatManager) : base(webSocketConnectionManager)
        {
            _chatManager = chatManager;
        }

        public async Task SendMessage(Guid chatroomId,string userid, string message)
        {
            var channelViewModel = new ChannelViewModel
            {
                MessageString = message,
                ChatroomId = chatroomId,
                UserId = userid
            };
            //_chatManager.MessageCreate(channelViewModel); 
            await InvokeClientMethodToAllAsync("pingMessage", chatroomId, userid, message);
        }
    }
}
