using Microsoft.AspNetCore.Mvc;
using NewKinoHub.Manager.Home;

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
        public HomeController(IHomeManager mediaManager) => _media = mediaManager;

        public IActionResult Index()
        {
            var film = _media.GetNewPopularFilms();
            return View(film);
        }
        public IActionResult Search(string Name)
        {
            ViewBag.Director = _media.Cast(0);
            ViewBag.Actor = _media.Cast(2);
            ViewData["Getemployeedetails"] = Name;
            ViewBag.User = User.Identity.Name;
            var media = _media.Search(Name);
            return View(media);
        }
    }
}

