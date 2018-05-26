using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWARocketChat.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SWARocketChat.Controllers
{
    [Route("Login")]
    public class LoginController : BaseController
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View(new User());
        }

        [HttpPost("")]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind("Username,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                if (DbContext.Users.Any(r => r.Username == user.Username) &&
                    DbContext.Users.Any(r => r.Password == user.Password))
                    return RedirectToAction("Index", "Home");
            }
            //ModelState.AddModelError("", "Username or Password not correct");
            return View(user);
        }
        [HttpGet("ForgotPassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        
        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("Register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Id,Username,Password,Password2,Email")] User user)
        {
            if (ModelState.IsValid)
            {
                if (DbContext.Users.Any(r => r.Username == user.Username))
                {
                    ModelState.AddModelError("", "Username already exist");
                    //return RedirectToAction(nameof(Register));
                }
                if (DbContext.Users.Any(r => r.Email == user.Email))
                {
                    ModelState.AddModelError("", "Email already exist");
                }

                if (user.Password!=user.Password2)
                {
                    ModelState.AddModelError("", "Password dont match");
                }
                else
                {
                    DbContext.Add(user);
                    await DbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                
            }
            return View(user);
        }

        // GET: Login/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await DbContext.Users.SingleOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Login/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Username,Password,UserImage,Email")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    DbContext.Update(user);
                    await DbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        // GET: Login/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await DbContext.Users
                .SingleOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Login/Delete/5
        [HttpPost("Delete"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var user = await DbContext.Users.SingleOrDefaultAsync(m => m.Id == id);
            DbContext.Users.Remove(user);
            await DbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(Guid id)
        {
            return DbContext.Users.Any(e => e.Id == id);
        }
    }
}
