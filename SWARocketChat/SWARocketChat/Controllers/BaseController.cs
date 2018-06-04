using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SWARocketChat.Data;
using SWARocketChat.Models;

namespace SWARocketChat.Controllers
{
    public class BaseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BaseController(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Chatroom> GetAllRooms()
        {
            return _context.Chatrooms.ToList();
        }
        //protected readonly RocketChatContext DbContext = new RocketChatContext();
        //protected readonly ApplicationDbContext DbContext = new ApplicationDbContext();
    }
}