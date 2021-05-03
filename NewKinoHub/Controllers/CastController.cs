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
        public async Task<IActionResult> Person(int castId)
        {
            var person = await _cast.GetCastforId(castId);
            return View(person);
        }
    }
}
