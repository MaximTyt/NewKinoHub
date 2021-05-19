using KinoHab.Manager;
using Microsoft.AspNetCore.Mvc;
using NewKinoHub.Manager.Userss;
using System.Threading.Tasks;

namespace KinoHab.Controllers
{
    public class FilmsController : Controller
    {
        private readonly IFilmManager _film;
        private readonly IUserManager _user;

        public FilmsController(IFilmManager filmManager, IUserManager userManager)
        {
            _film = filmManager;
            _user = userManager;

        }

        public async Task<IActionResult> ListSerials(string sort)
        {
            var serial = await _film.GetFilms(await _film.GetUser(User.Identity.Name));
            ViewBag.Director = _film.Cast(0);
            ViewBag.Actor = _film.Cast(2);
            ViewBag.User = User.Identity.Name;
            ViewBag.Type = _film.TypeFilm("Serial");
            ViewBag.Role = _user.GetRights(await _user.GetUsers(User.Identity.Name));
            if (sort != null)
            {
                var Sort = await _film.AllSorting(sort, await _film.GetUser(User.Identity.Name));
                return View(Sort);
            }
            return View(serial);
        }

        public async Task<IActionResult> ListFilms(string sort)
        {
            var film = await _film.GetFilms(await _film.GetUser(User.Identity.Name));
            ViewBag.Director = _film.Cast(0);
            ViewBag.Actor = _film.Cast(2);
            ViewBag.User = User.Identity.Name;
            ViewBag.Role = _user.GetRights(await _user.GetUsers(User.Identity.Name));
            ViewBag.Type = _film.TypeFilm("Film");
            if (sort != null)
            {
                var Sort = await _film.AllSorting(sort, await _film.GetUser(User.Identity.Name));
                return View(Sort);
            }
            return View(film);
        }

        public async Task<IActionResult> Film(int IdFilm)
        {
            var film = await _film.GetFilmforId(IdFilm,await _film.GetUser(User.Identity.Name));
            ViewBag.Director = _film.Cast(0);
            ViewBag.SceenWriter = _film.Cast(1);
            ViewBag.Actor = _film.Cast(2);
            ViewBag.Role = _user.GetRights(await _user.GetUsers(User.Identity.Name));
            ViewBag.User = User.Identity.Name;
            ViewBag.UserId = _user.GetUserId(User.Identity.Name);
            ViewBag.Review = _film.UserReview(User.Identity.Name, IdFilm);
            
            return View(film);
        }

        public async Task<IActionResult> Filtrations(string sort, string type, int filtr)
        {
            ViewBag.Director = _film.Cast(0);
            ViewBag.Actor = _film.Cast(2);
            ViewBag.Filtrr = _film.GetNameFiltr(filtr);
            ViewBag.filtr = filtr;
            ViewBag.type = _film.TypeFilm(type);
            ViewBag.User = User.Identity.Name;
            ViewBag.Role = _user.GetRights(await _user.GetUsers(User.Identity.Name));
            var Filtr = await _film.Filtration(filtr,await _film.GetUser(User.Identity.Name));
            if (sort != null)
            {
                var Sort = await _film.SortingFromFiltr(sort,Filtr);
                return View(Sort);
            }
            return View(Filtr);
        }

        public async Task<IActionResult> DeleteFilm(int IdFilm)
        {
            await _film.DeleteFilm(IdFilm);
            return RedirectToAction("ListFilms", "Films");
        }

        [HttpPost]
        public async Task<ActionResult> AddFilms(string mainPhoto, string Name, int Year, string Contry, int Age, string RunTime, string Description, string shortDiscription, string Score, string ScoreKP, string Music, string Video, int Day, string month,int NumOfEpisodes,int NumOfSeason, int type)
        {
            await _film.AddFilm(mainPhoto, Name, Year, Contry, Age, RunTime, Description, shortDiscription, Score, ScoreKP, Music, Video, Day, month, NumOfEpisodes, NumOfSeason,type);
            return RedirectToAction("ListFilms", "Films");
        }
        [HttpPost]
        public async Task<ActionResult> EditFilms(string mainPhoto, string Name, int Year, string Contry, int Age, string RunTime, string Description, string shortDiscription, string Score, string ScoreKP, string Music, string Video, int Id, int Day, string month, int NumOfEpisodes, int NumOfSeason, int type)
        {
            await _film.EditFilm(mainPhoto, Name, Year, Contry, Age, RunTime, Description, shortDiscription, Score, ScoreKP, Music, Video,Id,Day,month, NumOfEpisodes, NumOfSeason,type);
            return RedirectToAction("ListFilms", "Films");
        }

        public IActionResult AddFilm()
        {
            return View();
        }
        public async Task <IActionResult> EditFilm(int id)
        {
            var Film = await _film.GetFilmforId(id, await _film.GetUser(User.Identity.Name));
            return View(Film);
        }

        [HttpPost]
        public async Task<ActionResult> AddReviews(int IdFilm, string text)
        {
            await _film.AddReviews(IdFilm, User.Identity.Name, text);
            return RedirectToAction("Film", "Films", new { IdFilm = IdFilm });
        }

        [HttpPost]
        public async Task<ActionResult> EditReviews(int IdFilm, string text)
        {
            await _film.EditReviews(IdFilm, _user.GetUserId(User.Identity.Name), text);
            return RedirectToAction("Film", "Films", new { IdFilm = IdFilm });
        }
        public async Task<ActionResult> DeleteReviews(int IdFilm, string Email)
        {
            await _film.DeleteReviews(IdFilm, Email);
            return RedirectToAction("Film", "Films", new { IdFilm = IdFilm });
        }
    }
}
