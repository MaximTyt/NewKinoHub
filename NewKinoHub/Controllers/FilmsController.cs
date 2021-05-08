using KinoHab.Manager;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KinoHab.Controllers
{
    public class FilmsController : Controller
    {
        private readonly IFilmManager _film;

        public FilmsController(IFilmManager filmManager)
        {
            _film = filmManager;

        }

        public async Task<IActionResult> ListSerials(string sort, string type)
        {
            ViewBag.Director = _film.Cast(0);
            ViewBag.Actor = _film.Cast(2);
            ViewBag.User = User.Identity.Name;
            if (sort != null)
            {
                var Sort = await _film.AllSorting(sort, type);
                return View(Sort);
            }
            var serial = await _film.GetAllSerials();
            return View(serial);
        }

        public async Task<IActionResult> ListFilms(string sort, string type)
        {
            var film = await _film.GetAllFilms();
            ViewBag.Director = _film.Cast(0);
            ViewBag.Actor = _film.Cast(2);
            ViewBag.User = User.Identity.Name;
            if (sort != null)
            {
                var Sort = await _film.AllSorting(sort, type);
                return View(Sort);
            }
            return View(film);
        }

        public async Task<IActionResult> Film(int IdFilm)
        {
            var film = await _film.GetFilmforId(IdFilm);
            ViewBag.Director = _film.Cast(0);
            ViewBag.SceenWriter = _film.Cast(1);
            ViewBag.Actor = _film.Cast(2);
            ViewBag.User = User.Identity.Name;
            
            return View(film);
        }

        public async Task<IActionResult> Filtrations(string sort, string type, int filtr)
        {
            ViewBag.Director = _film.Cast(0);
            ViewBag.Actor = _film.Cast(2);
            ViewBag.Filtrr = _film.GetNameFiltr(filtr);
            ViewBag.filtr = filtr;
            ViewBag.type = type;
            ViewBag.User = User.Identity.Name;
            var Filtr = await _film.Filtration(filtr, type);
            if (sort != null)
            {
                var Sort = await _film.SortingFromFiltr(sort,Filtr);
                return View(Sort);
            }
            return View(Filtr);
        }
    }
}
