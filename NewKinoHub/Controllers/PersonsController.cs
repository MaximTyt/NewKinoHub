using Microsoft.AspNetCore.Mvc;
using NewKinoHub.Manager.Persons;
using NewKinoHub.Manager.Userss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewKinoHub.Controllers
{
    public class PersonsController : Controller
    {
        private readonly IUserManager _user;
        private readonly IPersonManager _person;

        public PersonsController(IUserManager userManager, IPersonManager person)
        {
            _user = userManager;
            _person = person;
        }

        public async Task<IActionResult> ListPersons()
        {
            ViewBag.Role = _user.GetRights(await _user.GetUsers(User.Identity.Name));
            var persons = await _person.GetPersons();
            return View(persons);
        }

        public async Task<IActionResult> Person(int personId)
        {
            ViewBag.Role = _user.GetRights(await _user.GetUsers(User.Identity.Name));
            var person = await _person.GetPersonForId(personId);
            return View(person);
        }

        public async Task<IActionResult> DeletePerson(int IdPerson)
        {
            await _person.DeletePerson(IdPerson);
            return RedirectToAction("ListPersons", "Persons");
        }
    }
}
