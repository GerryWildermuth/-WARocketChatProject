using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWARocketChat.Models;

namespace SWARocketChat.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
       
        [HttpGet("")]
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
