using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWARocketChat.Data;
using SWARocketChat.Models;
using SWARocketChat.Services;

namespace SWARocketChat.Controllers
{
    [Route("")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _dbContext;
        private readonly ChatHandler _chatHandler;
        public HomeController(
            UserManager<ApplicationUser> userManager, ApplicationDbContext context, ChatHandler chatHandler)
        {
            _userManager = userManager;
            _dbContext = context;
            _chatHandler = chatHandler;
        }
        [HttpGet("")]
        
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            ViewBag.UserRoomList = await _dbContext.Users
                .Include(u => u.UserRoomList)
                .ThenInclude(c => c.Chatroom.Messages)
                .Where(c => c.UserRoomList
                    .Any(u => u.ApplicationUserId == currentUser.Id))
                .FirstOrDefaultAsync(u => u.Id == currentUser.Id);

            //ViewBag.UserRoomList = await _dbContext.Users
            //    .Include(u => u.UserRoomList)
            //    .ThenInclude(c => c.Chatroom.Messages)
            //    .ThenInclude(c=>c.Chatroom.ChatroomMembers.UserChatroomMembers)
            //    .ThenInclude(c=>c.ChatroomMembers)
            //    .Where(c => c.UserRoomList
            //        .Any(u => u.ApplicationUserId == currentUser.Id))
            //    .FirstOrDefaultAsync(u => u.Id == currentUser.Id);

            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
