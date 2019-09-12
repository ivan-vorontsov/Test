using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManager.Models;

namespace UserManager.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager;
        public HomeController(Microsoft.AspNetCore.Identity.UserManager<AppUser> userMgr)
        {
            userManager = userMgr;
        }
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            ViewBag.userName = user.UserName;
            return View();
        }
    }
}
