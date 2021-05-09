using KinoHab.Manager;
using Microsoft.AspNetCore.Mvc;
using NewKinoHub.Manager.Home;
using System.Threading.Tasks;

namespace NewKinoHub.Controllers
{
    public class HomeController : Controller
    {        
       //[Authorize]
       //public IActionResult Index()
       //{
       //    return Content(User.Identity.Name);
       //}
        private readonly IHomeManager _media;
        private readonly IFilmManager _film;
        public HomeController(IHomeManager mediaManager, IFilmManager FilmManager)
        {
            _media = mediaManager;
            _film = FilmManager;
        }

        public IActionResult Index()
        {
            var film = _media.GetNewPopularFilms();
            return View(film);
        }
        public async Task<IActionResult> Search(string Name)
        {
            ViewBag.Director = _media.Cast(0);
            ViewBag.Actor = _media.Cast(2);
            ViewData["Getemployeedetails"] = Name;
            ViewBag.User = User.Identity.Name;
            var media = await _media.Search(Name,await _film.GetUser(User.Identity.Name));
            return View(media);
        }
    }
}

