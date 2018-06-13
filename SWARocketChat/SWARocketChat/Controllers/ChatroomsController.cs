using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWARocketChat.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using SWARocketChat.Data;
using SWARocketChat.Models.ChatroomViewModels;
using SWARocketChat.Services;

namespace SWARocketChat.Controllers
{
    [Authorize]
    [Route("Chatrooms")]
    public class ChatroomsController : Controller 
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _dbContext;
        private readonly ChatHandler _chatHandler;
        public ChatroomsController(
            UserManager<ApplicationUser> userManager, ApplicationDbContext context,ChatHandler chatHandler)
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
                .ThenInclude(c=>c.Chatroom.Messages)
                .Where(c=>c.UserRoomList
                    .Any(u=>u.ApplicationUserId==currentUser.Id))
                .FirstOrDefaultAsync(u => u.Id == currentUser.Id);

            return View(await _dbContext.Chatrooms
                .Include(a => a.ChatroomMembers)
                .Where(a => a.ChatroomMembers.ChatroomId == a.Id)
                .Include(u => u.ChatroomMembers.UserChatroomMembers)
                .ThenInclude(u=>u.User)
                .ToListAsync());
        }
        
        [HttpGet("Channel")]
        public async Task<IActionResult> Channel(Guid id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var userwithUserRoomList = await _dbContext.Users
                .Include(u => u.UserRoomList)
                .ThenInclude(c => c.Chatroom.Messages)
                .FirstOrDefaultAsync(u => u.Id == currentUser.Id);
            var currentChatroom = await _dbContext.Chatrooms
                .Include(u => u.ChatroomMembers.UserChatroomMembers)
                .ThenInclude(u => u.User)
                .FirstOrDefaultAsync(c => c.Id == id);
            var currentChatroomWithMembers = currentChatroom.ChatroomMembers.UserChatroomMembers.Select(u => u.User);

            if (currentChatroomWithMembers.Any(c => c.Id == currentUser.Id) == false)
            {
                var userChatroomMember = new UserChatroomMember
                {
                    ChatroomMembers = currentChatroom.ChatroomMembers,
                    User = currentUser
                };
                await _dbContext.AddAsync(userChatroomMember);
                await _dbContext.SaveChangesAsync();
            }

            var userRoomList = new UserRoomList
            {
                Chatroom = currentChatroom,
                ChatroomId = id,
                ChatroomStatus = 0,
                ApplicationUserId = currentUser.Id
            };
            if(currentUser.UserRoomList!=null)
            if (!((userwithUserRoomList.UserRoomList.Any(c => c.ChatroomId == currentChatroom.Id))
                &&(userwithUserRoomList.UserRoomList.Any(c => c.ApplicationUserId == currentUser.Id))))
            {
                await _dbContext.AddAsync(userRoomList);
                currentUser.UserRoomList.Add(userRoomList);
                _dbContext.Update(currentUser);
                await _dbContext.SaveChangesAsync();
            }
            var customemodel = await _dbContext.Chatrooms
                .Include(a => a.ChatroomMembers.UserChatroomMembers)
                .ThenInclude(a=>a.User)
                .Include(chatroom => chatroom.Messages)
                .Where(chatroom => chatroom.Id == id)
                .Select(m => new ChannelViewModel
                {
                    Chatroom = m,
                    ChatroomId = m.Id,
                    UserId = currentUser.Id
                }).FirstOrDefaultAsync();
            var users = _userManager.Users;
            ViewBag.Users = users.Select(x =>
                new SelectListItem()
                {
                    Text = x.UserName,
                    Value = x.ToString()
                });
            ViewBag.UserRoomList = await _dbContext.Users
                .Include(u => u.UserRoomList)
                .ThenInclude(c => c.Chatroom.Messages)
                .Where(c => c.UserRoomList
                    .Any(u => u.ApplicationUserId == currentUser.Id))
                .FirstOrDefaultAsync(u => u.Id == currentUser.Id);
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
                var currentUser = await _userManager.GetUserAsync(User);

                var chatroom = new Chatroom
                {
                    ChatroomName = model.ChatroomName,
                    ChatroomTopic = model.ChatroomTopic,
                    ChatroomDesription = model.ChatroomDesription,
                    Password = model.Password,
                    Private = model.Private,
                    ChatroomMembers = new ChatroomMembers()
                };
                if (currentUser != null)
                {
                    var chatroomMembers = new ChatroomMembers
                    {
                        ChatroomId = chatroom.Id,
                        UserChatroomMembers = new List<UserChatroomMember>()
                    };
                    var currentuserChatroomMember = new UserChatroomMember
                    {
                        ChatroomMembers = chatroomMembers,
                        User = currentUser
                    };
                    chatroomMembers.UserChatroomMembers.Add(currentuserChatroomMember);

                    if (model.ChatroomMembers != null)
                    {
                        foreach (var member in model.ChatroomMembers)
                        {
                            var user = await _userManager.FindByNameAsync(member);
                            if (!chatroomMembers.UserChatroomMembers.Select(c => c.User).Contains(user))
                            {
                                var userChatroomMember = new UserChatroomMember
                                {
                                    ChatroomMembers = chatroomMembers,
                                    User = user
                                };
                                chatroomMembers.UserChatroomMembers.Add(userChatroomMember);
                            }
                        }
                    }
                    _dbContext.Add(chatroom);
                    await _dbContext.SaveChangesAsync();

                    _dbContext.Add(chatroomMembers);
                    await _dbContext.SaveChangesAsync();


                    var userwithUserRoomList = await _dbContext.Users
                        .Include(u => u.UserRoomList)
                        .ThenInclude(c => c.Chatroom.Messages)
                        .FirstOrDefaultAsync(u => u.Id == currentUser.Id);
                    var userRoomList = new UserRoomList
                    {
                        Chatroom = chatroom,
                        ChatroomId = chatroom.Id,
                        ChatroomStatus = 0,
                        ApplicationUserId = currentUser.Id
                    };
                    if (currentUser.UserRoomList != null)
                    {
                        if (!((userwithUserRoomList.UserRoomList.Any(c => c.ChatroomId == chatroom.Id))
                              && (userwithUserRoomList.UserRoomList.Any(c => c.ApplicationUserId == currentUser.Id))))
                        {
                            await _dbContext.AddAsync(userRoomList);
                            currentUser.UserRoomList.Add(userRoomList);
                            _dbContext.Update(currentUser);
                            await _dbContext.SaveChangesAsync();
                        }
                    }
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
        
        [HttpGet("SendMessage")]
        public async Task SendMessage([FromQuery]Guid chatroomId, string userid, string message)
        {
            if (userid != null)
            {
                var currentUser = await _userManager.FindByIdAsync(userid);
                var chatroom = await _dbContext.Chatrooms.FirstOrDefaultAsync(c => c.Id == chatroomId);
                var mymessage = new Message
                {
                    ChatroomId = chatroomId,
                    User = currentUser,
                    MessageString = message
                };
                await _chatHandler.InvokeClientMethodToAllAsync("receiveMessage", currentUser.UserName,
                    currentUser.UserImage, mymessage.MessageTime.ToString("HH:mm"), message);
                if (chatroom != null)
                {
                    await _dbContext.AddAsync(mymessage);
                    chatroom.Messages.Add(mymessage);
                    _dbContext.Update(chatroom);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
        
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
                        if (!chatroom.ChatroomMembers.UserChatroomMembers.Select(c => c.User).Contains(user))
                        {
                            var userChatroomMember = new UserChatroomMember
                            {
                                ChatroomMembers = chatroom.ChatroomMembers,
                                User = user
                            };
                            chatroom.ChatroomMembers.UserChatroomMembers.Add(userChatroomMember);
                        }
                    }

                    _dbContext.Update(chatroom);
                    await _dbContext.SaveChangesAsync();
                }
                return RedirectToAction("Channel", "Chatrooms", new {chatroom.Id});
            }
            return RedirectToAction("Channel", "Chatrooms", new { model.ChatroomId });
        }
        [HttpGet("LeaveRoom")]
        public async Task<IActionResult> LeaveRoom(Guid id)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                var userwithUserRoomList = await _dbContext.Users
                    .Include(u => u.UserRoomList)
                    .ThenInclude(c => c.Chatroom.Messages)
                    .FirstOrDefaultAsync(u => u.Id == currentUser.Id);
                var currentChatroom = await _dbContext.Chatrooms
                    .Include(u => u.ChatroomMembers.UserChatroomMembers)
                    .ThenInclude(u => u.User)
                    .FirstOrDefaultAsync(c => c.Id == id);
                var currentChatroomWithMembers = currentChatroom.ChatroomMembers.UserChatroomMembers.FirstOrDefault(c=>c.ApplicationUserId==currentUser.Id);
                if (currentChatroomWithMembers!=null)
                {
                    _dbContext.Remove(currentChatroomWithMembers);
                    _dbContext.Update(currentChatroom);
                    _dbContext.Update(currentUser);
                    //currentChatroomWithMembers.Remove(currentUser);
                    await _dbContext.SaveChangesAsync();
                }
                

                if (currentUser.UserRoomList != null)
                    if (((userwithUserRoomList.UserRoomList.Any(c => c.ChatroomId == currentChatroom.Id))
                          && (userwithUserRoomList.UserRoomList.Any(c => c.ApplicationUserId == currentUser.Id))))
                    {
                        var currentUserRoomList = currentUser.UserRoomList.FirstOrDefault(c => c.ChatroomId == id);
                        if (currentUserRoomList != null)
                        {
                            _dbContext.Remove(currentUserRoomList);
                            currentUser.UserRoomList.Remove(currentUserRoomList);
                        }
                        _dbContext.Update(currentUser);
                        await _dbContext.SaveChangesAsync();
                    }
            }
            return RedirectToAction("Index", "Home");
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
        [HttpPost("Edite")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ChannelViewModel model)
        {
            model.MessageString = "";//test so see if initialiation works here as well and counts as valid
            if (ModelState.IsValid)
            {
                _dbContext.Update(model.Chatroom);
                await _dbContext.SaveChangesAsync();    
                return RedirectToAction("Channel", "Chatrooms", model);
            }
            return RedirectToAction("Channel","Chatrooms", model);
        }
    }
}
