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
        public async Task<IActionResult> Profile()
        {
            var user = await _user.GetUsers(User.Identity.Name);
            return View(user);
        }

        public async Task<IActionResult> AddFilms(int id)
        {
            await _user.AddFilms(id,User.Identity.Name);
            return RedirectToAction("Film","Films", new { IdFilm = id });
        }

        public async Task<IActionResult> DeleteFavoriteFilms(int id)
        {
            await _user.DeleteFavoriteFilms(id, User.Identity.Name);
            return RedirectToAction("Film", "Films", new { IdFilm = id });
        }

        [HttpPost]
        public async Task<ActionResult> EditAccount(string mainPhoto, string name, string DataB)
        {
            await _user.EditAccount(mainPhoto, name, DataB, User.Identity.Name);
            return RedirectToAction("Profile", "User");
        }
    }
}
