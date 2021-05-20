using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewKinoHub.Manager;
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
            if (_user.ImageNull(User.Identity.Name) != true)
                ViewBag.Image = _user.GetImage(User.Identity.Name);
            var user = await _user.GetUsers(User.Identity.Name);
            return View(user);
        }

        public async Task<IActionResult> AddFilms(int id)
        {
            await _user.AddFavoriteFilms(id,User.Identity.Name);
            return RedirectToAction("Film","Films", new { IdFilm = id });
        }

        public async Task<IActionResult> AddViewedFilms(int id)
        {
            await _user.AddViewedFilms(id, User.Identity.Name);
            return RedirectToAction("Film", "Films", new { IdFilm = id });
        }

        public async Task<IActionResult> DeleteViewedFilms(int id)
        {
            await _user.DeleteViewedFilms(id, User.Identity.Name);
            return RedirectToAction("Film", "Films", new { IdFilm = id });
        }

        public async Task<IActionResult> DeleteViewedFilms1(int id)
        {
            await _user.DeleteViewedFilms(id, User.Identity.Name);
            return RedirectToAction("Profile", "User");
        }

        public async Task<IActionResult> DeleteFavoriteFilms(int id)
        {
            await _user.DeleteFavoriteFilms(id, User.Identity.Name);
            return RedirectToAction("Film", "Films", new { IdFilm = id });
        }

        public async Task<IActionResult> DeleteFavoriteFilms1(int id)
        {
            await _user.DeleteFavoriteFilms(id, User.Identity.Name);
            return RedirectToAction("Profile", "User");
        }

        [HttpPost]
        public async Task<ActionResult> EditAccount(IFormFile mainPhoto, string name, DateTime DataB)
        {
            await _user.EditAccount(mainPhoto, name, DataB, User.Identity.Name);
            return RedirectToAction("Profile", "User");
        }
    }
}
