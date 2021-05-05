using Microsoft.AspNetCore.Mvc;
using NewKinoHub.Manager.Casts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewKinoHub.Controllers
{
    public class CastController : Controller
    {
        private readonly ICastManager _cast;

        public CastController(ICastManager castManager)
        {
            _cast = castManager;

        }
        public async Task<IActionResult> Person(int personId)
        {
            var person = await _cast.GetPersonforId(personId);
            return View(person);
        }

        public async Task<IActionResult> ListCast(int castId)
        {
            ViewBag.Director = _cast.Cast(0);
            ViewBag.SceenWriter = _cast.Cast(1);
            ViewBag.Actor = _cast.Cast(2);
            var cast = await _cast.GetAllCast(castId);
            return View(cast);
        }
    }
}
