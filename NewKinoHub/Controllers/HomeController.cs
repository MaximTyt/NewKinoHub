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
            ViewData["Getemployeedetails"] = Name;
            var media = _media.Search(Name);
            return View(media);
        }
    }
}

