using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using SWARocketChat.Data;
using SWARocketChat.Models;
using SWARocketChat.Models.AccountViewModels;

namespace SWARocketChat.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public LoginController(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            return View(new ApplicationUser());
        }

        //[HttpPost("")]
        //[ValidateAntiForgeryToken]
        //public IActionResult Index(LoginViewModel model,string returnUrl = null)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var thisuser = _dbContext.Users.FirstOrDefault(r => r.Username == user.Username);
        //        if (thisuser != null && thisuser.Username == user.Username && thisuser.Password == user.Password)
        //            return RedirectToAction("Index", "Home");
        //        ModelState.AddModelError("", "Username or Password not correct");
        //    }
        //    return View(user);
        //}
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

        //[HttpPost("Register")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Register([Bind("Id,Username,Password,Password2,Email")] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (_dbContext.Users.Any(r => r.Username == user.Username))
        //        {
        //            ModelState.AddModelError("", "Username already exist");
        //            //return RedirectToAction(nameof(Register));
        //        }
        //        if (_dbContext.Users.Any(r => r.Email == user.Email))
        //        {
        //            ModelState.AddModelError("", "Email already exist");
        //        }

        //        if (user.Password!=user.Password2)
        //        {
        //            ModelState.AddModelError("", "Password dont match");
        //        }
        //        else
        //        {
        //            _dbContext.Add(user);
        //            await _dbContext.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }

        //    }
        //    return View(user);
        //}
        //private bool UserExists(Guid id)
        //{
        //    return _dbContext.Users.Any(e => e.Id == id);
        //}
    }
}
