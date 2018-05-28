using Microsoft.AspNetCore.Mvc;
using SWARocketChat.Models;

namespace SWARocketChat.Controllers
{
    public class BaseController : Controller
    {
        protected BaseController() { }

        protected readonly RocketChatContext DbContext = new RocketChatContext();
    }
}