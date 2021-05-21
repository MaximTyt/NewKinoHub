using Microsoft.AspNetCore.Mvc;
using NewKinoHub.Manager.Casts;
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

        public CastController(ICastManager castManager, IUserManager userManager)
        {
            _cast = castManager;
            _user = userManager;

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
        public async Task<IActionResult> ListCasts(int IdFilm,int i)
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

        public IActionResult AddCasts(int IdFilm)
        {
            ViewBag.IdFilm = IdFilm;
            return View();
        }

        public IActionResult SearchOrAddCast(int IdFilm)
        {
            ViewBag.IdFilm = IdFilm;
            return View();
        }

        public IActionResult SearchPerson(int IdFilm, string Name)
        {
            var person = _cast.Search(Name);
            ViewBag.IdFilm = IdFilm;
            ViewData["Geetemployeedetails"] = Name;
            if(Name == null)
            {
                person = null;
            }
            return View(person);
        }

        public async Task<IActionResult> AddSearchPerson(int IdFilm,int IdPerson)
        {
            ViewBag.IdFilm = IdFilm;
            await _cast.AddSearchPerson(IdFilm, IdPerson);
            return RedirectToAction("Film", "Films", new { IdFilm });
        }

        //public IActionResult Search(int IdFilm, string Name)
        //{
        //    ViewBag.IdFilm = IdFilm;
        //    ViewData["Getemployeedetails"] = Name;
        //    var person = _cast.Search(Name);
        //    return View(person);
        //}

        public async Task<IActionResult> DeleteCast(int IdFilm,int IdCast)
        {
            await _cast.DeleteCast(IdCast);
            return RedirectToAction("ListCasts", "Cast", new { IdFilm });
        }
    }
}
