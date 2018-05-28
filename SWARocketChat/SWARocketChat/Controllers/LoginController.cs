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
        public IActionResult Index([Bind("Id,Username,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                var thisuser = DbContext.Users.FirstOrDefault(r => r.Username == user.Username);
                if (thisuser != null && thisuser.Username == user.Username && thisuser.Password == user.Password)
                    return RedirectToAction("Index", "Home");
                ModelState.AddModelError("", "Username or Password not correct");
            }
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
        private bool UserExists(Guid id)
        {
            return DbContext.Users.Any(e => e.Id == id);
        }
    }
}
