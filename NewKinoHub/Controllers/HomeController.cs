using KinoHab.Manager;
using Microsoft.AspNetCore.Mvc;
using NewKinoHub.Manager.Home;
using NewKinoHub.Manager.Userss;
using System.Threading.Tasks;

namespace NewKinoHub.Controllers
{
    public class HomeController : Controller
    {        

        private readonly IHomeManager _media;
        private readonly IFilmManager _film;
        private readonly IUserManager _user;
        public HomeController(IHomeManager mediaManager, IFilmManager FilmManager, IUserManager userManager)
        {
            _media = mediaManager;
            _film = FilmManager;
            _user = userManager;
        }

        public async Task<IActionResult> Index()
        {

            var film = _media.GetNewPopularFilms(User.Identity.Name);
            return View(film);
        }
        public async Task<IActionResult> Search(string Name)
        {
            ViewBag.Role = _user.GetRights(await _user.GetUsers(User.Identity.Name));
            ViewData["Getemployeedetails"] = Name;
            ViewBag.User = User.Identity.Name;
            var media = await _media.Search(Name,await _film.GetUser(User.Identity.Name));
            return View(media);
        }
        public async Task<IActionResult> AdvancedSearch()
        {
            ViewBag.Role = _user.GetRights(await _user.GetUsers(User.Identity.Name));            
            ViewBag.User = User.Identity.Name;
            var person = await _media.AdvancedSearch(await _film.GetUser(User.Identity.Name));
            return View(person);
        }

    }
}

