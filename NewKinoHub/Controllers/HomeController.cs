using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewKinoHub.Models;
using System.Diagnostics;

namespace NewKinoHub.Controllers
{
    public class HomeController : Controller
    {        
        [Authorize]
        public IActionResult Index()
        {
            return Content(User.Identity.Name);
        }       
    }
}
