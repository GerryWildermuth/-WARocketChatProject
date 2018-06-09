using WebSocketManager;

namespace SWARocketChat.Services
{
    public class ChatHandler: WebSocketHandler
    {
        public ChatHandler(WebSocketConnectionManager webSocketConnectionManager) : base(webSocketConnectionManager)
        {
        }
    }
}