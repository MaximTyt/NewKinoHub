using KinoHab.Manager;
using Microsoft.AspNetCore.Mvc;

namespace KinoHab.Controllers
{
    public class SerialsController : Controller
    {
        private readonly ISerialManager _serial;
      
        public SerialsController(ISerialManager serialManager)
        {
            _serial = serialManager;
      
        }
        public IActionResult ListSerials()
        {
            var serial = _serial.GetAllSerials();
            return View(serial);
        }

        public IActionResult Serial(int SerialId)
        {
            var serials = _serial.GetSerialforId(SerialId);
            return View(serials);
        }

       // public IActionResult Sorting(string sort)
       // {
       //     var film = _serial.Sorting(sort);
       //     return View(film);
       // }

    }
}
