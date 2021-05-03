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
            if (sort != null)
            {
                var Sort = await _film.AllSorting(sort, type);
                return View(Sort);
            }
            var serial = await _film.GetAllSerials();
            return View(serial);
        }

        public IActionResult Serial(int SerialId)
        {
            ViewBag.Director = _film.Cast(0);
            ViewBag.SceenWriter = _film.Cast(1);
            ViewBag.Actor = _film.Cast(2);
            var serials = _film.GetSerialforId(SerialId);
            return View(serials);
        }

        public async Task<IActionResult> ListFilms(string sort, string type,int filtr)
        {
            ViewBag.Director = _film.Cast(0);
            ViewBag.Actor = _film.Cast(2);
            if(filtr != 0)
            {
                ViewBag.Filtr = _film.GetNameFiltr(filtr);
                var Filtr = await _film.Filtration(filtr, type);
                return View(Filtr);
            }
            if (sort != null)
            {
                var Sort = await _film.AllSorting(sort, type);
                return View(Sort);
            }
            var film = await _film.GetAllFilms();
            return View(film);
        }

        public async Task<IActionResult> Film(int IdFilm)
        {
            ViewBag.Director = _film.Cast(0);
            ViewBag.SceenWriter = _film.Cast(1);
            ViewBag.Actor = _film.Cast(2);
            var film = await _film.GetFilmforId(IdFilm);
            return View(film);
        }

        public async Task<IActionResult> Filtrations(string sort, string type, int filtr)
        {
            ViewBag.Director = _film.Cast(0);
            ViewBag.Actor = _film.Cast(2);
            ViewBag.Filtrr = _film.GetNameFiltr(filtr);
            ViewBag.filtr = filtr;
            ViewBag.type = type;
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
