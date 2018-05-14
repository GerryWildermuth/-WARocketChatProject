using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWARocketChat.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SWARocketChat.Controllers
{
    public class ChatroomsController : Controller
    {
        private readonly RocketChatContext _context;

        public ChatroomsController(RocketChatContext context)
        {
            _context = context;
        }

        // GET: Chatrooms
        public async Task<IActionResult> Index()
        {
            return View(await _context.Chatrooms.ToListAsync());
        }

        // GET: Chatrooms/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chatroom = await _context.Chatrooms
                .SingleOrDefaultAsync(m => m.Id == id);
            if (chatroom == null)
            {
                return NotFound();
            }

            return View(chatroom);
        }

        // GET: Chatrooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chatrooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ChatroomName,ChatroomDesription,ChatroomTopic,Password,LogedIn,MessageId")] Chatroom chatroom)
        {
            if (ModelState.IsValid)
            {
                chatroom.Id = Guid.NewGuid();
                _context.Add(chatroom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chatroom);
        }

        // GET: Chatrooms/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chatroom = await _context.Chatrooms.SingleOrDefaultAsync(m => m.Id == id);
            if (chatroom == null)
            {
                return NotFound();
            }
            return View(chatroom);
        }

        // POST: Chatrooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
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
                    _context.Update(chatroom);
                    await _context.SaveChangesAsync();
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

        // GET: Chatrooms/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chatroom = await _context.Chatrooms
                .SingleOrDefaultAsync(m => m.Id == id);
            if (chatroom == null)
            {
                return NotFound();
            }

            return View(chatroom);
        }

        // POST: Chatrooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var chatroom = await _context.Chatrooms.SingleOrDefaultAsync(m => m.Id == id);
            _context.Chatrooms.Remove(chatroom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChatroomExists(Guid id)
        {
            return _context.Chatrooms.Any(e => e.Id == id);
        }
    }
}
