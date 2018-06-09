using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWARocketChat.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using SWARocketChat.Data;
using SWARocketChat.Models.ChatroomViewModels;

namespace SWARocketChat.Controllers
{
    [Route("Chatrooms")]
    [Authorize]
    public class ChatroomsController : Controller 
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _dbContext;
        public ChatroomsController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = context;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            return View(await _dbContext.Chatrooms
                .Include(a => a.ChatroomMembers)
                .Where(a => a.ChatroomMembers.ChatroomId == a.Id)
                .Include(u => u.ChatroomMembers.Users)
                .ToListAsync());
        }
        
        [HttpGet("Channel")]
        public async Task<IActionResult> Channel(Guid id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var currentChatroom = await _dbContext.Chatrooms
                .Include(c => c.ChatroomMembers.Users)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (currentUser != null)
            {
                if (currentChatroom.ChatroomMembers.Users.Any(c => c.Id == currentUser.Id) == false)
                {
                    currentChatroom.ChatroomMembers.Users.Add(currentUser);
                    _dbContext.SaveChanges();
                }
            }
            var customemodel = await _dbContext.Chatrooms
                .Include(a => a.ChatroomMembers.Users)
                .Include(chatroom => chatroom.Messages)
                .Where(chatroom => chatroom.Id == id)
                .Select(m => new ChannelViewModel
                {
                    Chatroom = m,
                    ChatroomId = m.Id
                }).FirstOrDefaultAsync();
            var users = _userManager.Users;
            ViewBag.Users = users.Select(x =>
                new SelectListItem()
                {
                    Text = x.UserName,
                    Value = x.ToString()
                });
            return View(customemodel);
        }
        [HttpGet("Create")]
        public IActionResult Create()
        {
            var users = _userManager.Users;
            ViewBag.Users = users.Select(x =>
                new SelectListItem()
                {
                    Text = x.UserName,
                    Value = x.ToString()
                });
            return View();
        }
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateChatroomViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_dbContext.Chatrooms.Any(c => c.ChatroomName == model.ChatroomName))
                {
                ModelState.AddModelError("", "An Chatroom with this Name allready exists");
                    var users = _userManager.Users;
                    ViewBag.Users = users.Select(x =>
                        new SelectListItem()
                        {
                            Text = x.UserName,
                            Value = x.ToString()
                        });
                    return View(model);
                }

                var chatroom = new Chatroom
                {
                    ChatroomName = model.ChatroomName,
                    ChatroomTopic = model.ChatroomTopic,
                    ChatroomDesription = model.ChatroomDesription,
                    Password = model.Password,
                    Private = model.Private,
                    ChatroomMembers = new ChatroomMembers()
                };
                var currentUser = await _userManager.GetUserAsync(User);
                if (currentUser != null)
                {
                    var chatroomMembers = new ChatroomMembers
                    {
                        Users = new Collection<ApplicationUser> {currentUser},
                        ChatroomId = chatroom.Id
                    };


                    if (model.ChatroomMembers != null)
                        foreach (var member in model.ChatroomMembers)
                        {
                            var user = await _userManager.FindByNameAsync(member);
                            if (!chatroomMembers.Users.Contains(user))
                                chatroomMembers.Users.Add(user);
                        }
                    _dbContext.Add(chatroom);
                    await _dbContext.SaveChangesAsync();

                    _dbContext.Add(chatroomMembers);
                    await _dbContext.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            var currentuser = _userManager.Users;
            ViewBag.Users = currentuser.Select(x =>
                new SelectListItem()
                {
                    Text = x.UserName,
                    Value = x.ToString()
                });
            ModelState.AddModelError("", "Something went wrong try again");
            return View(model);
        }
        
        [HttpPost("MessageCreate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MessageCreate(ChannelViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser= await _userManager.GetUserAsync(User);
                var chatroom = await _dbContext.Chatrooms.FirstOrDefaultAsync(c => c.Id == model.ChatroomId);
                var message = new Message
                {
                    ChatroomId = model.ChatroomId,
                    User = currentUser,
                    MessageString = model.MessageString
                };
                if (chatroom != null)
                {
                    _dbContext.Add(message);
                    chatroom.Messages.Add(message);
                    _dbContext.Update(chatroom);
                    _dbContext.SaveChanges();

                    return RedirectToAction("Channel", "Chatrooms", new {chatroom.Id});
                }
            }
            return RedirectToAction("Channel", "Chatrooms", new { model.ChatroomId});
        }
        //[HttpPost("Edite")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,ChatroomName,ChatroomDesription,ChatroomTopic,Password,LogedIn,MessageId")] Chatroom chatroom)
        //{
        //    if (id != chatroom.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _dbContext.Update(chatroom);
        //            await _dbContext.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ChatroomExists(chatroom.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(chatroom);
        //}
        [HttpPost("AddUser")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(ChannelViewModel model)
        {
            if (ModelState.IsValid)
            {
                var chatroom = await _dbContext.Chatrooms.FirstOrDefaultAsync(c => c.Id == model.ChatroomId);
                if (chatroom.ChatroomMembers != null)
                {
                    foreach (var member in model.ChatroomMembers)
                    {
                        var user = await _userManager.FindByNameAsync(member);
                        if (!chatroom.ChatroomMembers.Users.Contains(user))
                            chatroom.ChatroomMembers.Users.Add(user);
                    }

                    _dbContext.Update(chatroom);
                    await _dbContext.SaveChangesAsync();
                }
                return RedirectToAction("Channel", "Chatrooms", new {chatroom.Id});
            }
            return RedirectToAction("Channel", "Chatrooms", new { model.ChatroomId });
        }
    
        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chatroom = await _dbContext.Chatrooms
                .SingleOrDefaultAsync(m => m.Id == id);
            if (chatroom == null)
            {
                return NotFound();
            }

            return View(chatroom);
        }

        [HttpPost("Delete"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var chatroom = await _dbContext.Chatrooms.SingleOrDefaultAsync(m => m.Id == id);
            //var chatroommember = await _dbContext.ChatroomMembers.SingleOrDefaultAsync(c => c.ChatroomId == id);

            //_dbContext.ChatroomMembers.Remove(chatroommember);
            _dbContext.Chatrooms.Remove(chatroom);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChatroomExists(Guid id)
        {
            return _dbContext.Chatrooms.Any(e => e.Id == id);
        }
    }
}
