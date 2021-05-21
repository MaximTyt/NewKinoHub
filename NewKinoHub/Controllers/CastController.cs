using Microsoft.AspNetCore.Mvc;
using NewKinoHub.Manager.Casts;
using NewKinoHub.Manager.Persons;
using NewKinoHub.Manager.Userss;
using NewKinoHub.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewKinoHub.Controllers
{
    public class CastController : Controller
    {
        private readonly ICastManager _cast;
        private readonly IUserManager _user;
        private readonly IPersonManager _person;

        public CastController(ICastManager castManager, IUserManager userManager, IPersonManager personManager)
        {
            _cast = castManager;
            _user = userManager;
            _person = personManager;

        }
        public async Task<IActionResult> Person(int personId)
        {
            var person = await _cast.GetPersonforId(personId);
            ViewBag.Role = _user.GetRights(await _user.GetUsers(User.Identity.Name));            
            return View(person);
        }

        public async Task<IActionResult> ListActors(int FilmId)
        {
            ViewBag.Role = _user.GetRights(await _user.GetUsers(User.Identity.Name));            
            var cast = await _cast.GetAllActors(FilmId);            
            return View(cast);
        }
        public async Task<IActionResult> ListCasts(int IdFilm)
        {            
            ViewBag.Role = _user.GetRights(await _user.GetUsers(User.Identity.Name));            
            var cast = await _cast.GetAllCast(IdFilm);
            return View(cast);
        }

        [HttpPost]
        public async Task<IActionResult> AddCast(int IdFilm, string Character, int RoleInFilm, string Name, string OriginalName,
            string RolesInMedia, double Height, string Image, DateTime DateOfBirthday, DateTime DateOfDeath, string PlaceOfBirthday,
            string PlaceOfDeath, string Spouse, string Awards, string Description)
        {
            await _cast.AddCast(IdFilm, Character, RoleInFilm, Name, OriginalName, RolesInMedia, Height, Image, DateOfBirthday, DateOfDeath, PlaceOfBirthday, 
                PlaceOfDeath, Spouse, Awards, Description);
            return RedirectToAction("Film","Films", new {IdFilm});
        }

        [HttpPost]
        public async Task<IActionResult> EditCast(int IdCast,int IdFilm, string Character, int RoleInFilm)
        {
            await _cast.EditCast(IdCast,IdFilm, Character, RoleInFilm);
            return RedirectToAction("ListCasts", "Cast", new { IdFilm });
        }

        public IActionResult AddCasts(int IdFilm)
        {
            ViewBag.IdFilm = IdFilm;
            return View();
        }

        public async Task<IActionResult> EditCasts(int IdCast, int IdFilm)
        {
            ViewBag.IdCast = IdCast;
            ViewBag.IdFilm = IdFilm;
            var cast = await _cast.GetCastForId(IdCast, IdFilm);
            return View(cast);
        }

        public IActionResult SearchOrAddCast(int IdFilm)
        {
            ViewBag.IdFilm = IdFilm;
            return View();
        }

        public async Task<IActionResult> SearchPerson(int IdFilm, string Name, int role)
        {
            var person = await _person.GetPersons();
            ViewBag.IdFilm = IdFilm;
            ViewBag.Role = role;
            ViewData["Geetemployeedetails"] = Name;
            if(Name != null)
            {
                person = _cast.Search(Name);
            }
            return View(person);
        }

        public async Task<IActionResult> AddSearchPerson(int IdFilm,int IdPerson, int role)
        {
            ViewBag.IdFilm = IdFilm;
            await _cast.AddSearchPerson(IdFilm, IdPerson, role);
            return RedirectToAction("Film", "Films", new { IdFilm });
        }

        public async Task<IActionResult> DeleteCast(int IdFilm,int IdCast)
        {
            await _cast.DeleteCast(IdCast);
            return RedirectToAction("ListCasts", "Cast", new { IdFilm });
        }
    }
}
