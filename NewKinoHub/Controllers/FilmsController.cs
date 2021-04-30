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
        public async Task<IActionResult> ListFilms()
        {
            var film = await _film.GetAllFilms();
            return View(film);
        }

        public async Task<IActionResult> Film(int IdFilm)
        {
            var film = await _film.GetFilmforId(IdFilm);
            return View(film);
        }   


     //  public IActionResult Sorting(string sort,int filtr)
     //  {
     //      var film = _film.AllSorting(sort);
     //      return View(film);
     //  }
     //
     //  public IActionResult Filtration(int filtr)
     //  {
     //      ViewBag.filtr = filtr;
     //      var film = _film.Filtration(filtr);
     //      return View(film);
     //  }
    }
}
