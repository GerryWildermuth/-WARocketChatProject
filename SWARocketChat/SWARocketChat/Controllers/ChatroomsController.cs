using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWARocketChat.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using SWARocketChat.Data;
using SWARocketChat.Models.ChatroomViewModels;

namespace SWARocketChat.Controllers
{
    [Route("Chatrooms")]
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
            return View(await _dbContext.Chatrooms.Include(a => a.ChatroomMembers).Where(a => a.ChatroomMembers.ChatroomId == a.Id).Include(u => u.ChatroomMembers.Users).ToListAsync());
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
                    Private = model.Private
                };
                
                var currentUser = await _userManager.GetUserAsync(User);
                var chatroomMembers = new ChatroomMembers
                {
                    Users = new Collection<ApplicationUser> { currentUser },
                    ChatroomId = chatroom.Id
                };
                if(model.ChatroomMembers!=null)
                    foreach (var member in model.ChatroomMembers)
                    {
                        var user = await _userManager.FindByNameAsync(member);
                        if(!chatroomMembers.Users.Contains(user))
                            chatroomMembers.Users.Add(user);
                    }
                _dbContext.Add(chatroom);
                await _dbContext.SaveChangesAsync();

                _dbContext.Add(chatroomMembers);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpGet("Channel")]
        public async Task<IActionResult> Channel(string channelname)
        {
            return View(await _dbContext.Chatrooms.Include(a => a.ChatroomMembers).Include(chatroom => chatroom.Messages).ToListAsync());
        }


        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chatroom = await _dbContext.Chatrooms.SingleOrDefaultAsync(m => m.Id == id);
            if (chatroom == null)
            {
                return NotFound();
            }
            return View(chatroom);
        }

        // POST: Chatrooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edite")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ChatroomName,ChatroomDesription,ChatroomTopic,Password,LogedIn,MessageId")] Chatroom chatroom)
        {
            if (id != chatroom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Update(chatroom);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChatroomExists(chatroom.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(chatroom);
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

    public class JsonData
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public JsonData(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
