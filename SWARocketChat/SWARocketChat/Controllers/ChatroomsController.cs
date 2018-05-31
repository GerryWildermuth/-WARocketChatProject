using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWARocketChat.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using SWARocketChat.Data;

namespace SWARocketChat.Controllers
{
    [Route("Chatrooms")]
    public class ChatroomsController : Controller 
    {
        private readonly ApplicationDbContext _dbContext;

        public ChatroomsController(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            return View(await _dbContext.Chatrooms.Include(a=>a.ChatroomMembers).ToListAsync());
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(new Chatroom());
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ChatroomName,ChatroomDesription,ChatroomTopic,Password,ChatroomMembers")] Chatroom chatroom)
        {
            if (ModelState.IsValid)
            {
                chatroom.Id = Guid.NewGuid();
                _dbContext.Add(chatroom);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chatroom);
        }
        [HttpGet("AutoComplete")]
        public JsonResult AutoComplete(string term)
        {
            var splittedString = term.Split(",");
            //term = splittedString[splittedString.Length];
            term = splittedString.LastOrDefault();
          var userlist = from n in _dbContext.Users where n.UserName.StartsWith(term)
                         select new { n.UserName };
            var liste = userlist.Select(x => x.UserName).ToList();
            return Json(liste);
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
