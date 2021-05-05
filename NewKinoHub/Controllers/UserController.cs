using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewKinoHub.Manager.Userss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewKinoHub.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserManager _user;
        
         public UserController(IUserManager userManager)
         {
            _user = userManager;
        
         }
        [Authorize]
        public IActionResult Profile()
        {
            var user = _user.GetUsers(User.Identity.Name);
            return View(user);
        }
    }
}
