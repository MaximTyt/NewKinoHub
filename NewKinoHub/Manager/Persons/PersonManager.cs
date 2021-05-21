using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewKinoHub.Storage;
using NewKinoHub.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewKinoHub.Manager.Persons
{
    public class PersonManager: IPersonManager
    {
        private readonly MvcFilmContext _context;
        public PersonManager(MvcFilmContext context)
        {
            _context = context;
        }

        public async Task DeletePerson(int IdPerson)
        {
            var ItemToRemove = await _context.Persons
                                             .Include(st=>st.Casts)
                                             .FirstOrDefaultAsync(st => st.Id == IdPerson);
            if(ItemToRemove != null)
            {
                _context.Persons.Remove(ItemToRemove);
                var ItemToRemove2 = await _context.Casts.FirstOrDefaultAsync(st => st.PersonId == IdPerson);
                if(ItemToRemove2 != null)
                {
                    _context.Casts.Remove(ItemToRemove2);
                }
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Person> GetPersonForId(int IdPerson)
        {
            return await _context.Persons.FirstOrDefaultAsync(st => st.Id == IdPerson);
        }

        public async Task<ICollection<Person>> GetPersons()
        {
            return await _context.Persons.ToListAsync();
        }
        public async Task AgeOfPerson(int personId)
        {
            if (_context.Persons.FirstOrDefault(st => st.Id == personId).DateOfBirthday.Year != 0001 && _context.Persons.FirstOrDefault(st => st.Id == personId).DateOfDeath.Year == 0001)
                _context.Persons.FirstOrDefault(st => st.Id == personId).Age = Convert.ToInt32(Math.Truncate((DateTime.Now.Date - _context.Persons.FirstOrDefault(st => st.Id == personId).DateOfBirthday).TotalDays / 365.2425));
            else if (_context.Persons.FirstOrDefault(st => st.Id == personId).DateOfBirthday.Year != 0001 && _context.Persons.FirstOrDefault(st => st.Id == personId).DateOfDeath.Year != 0001)
                _context.Persons.FirstOrDefault(st => st.Id == personId).Age = Convert.ToInt32(Math.Truncate((_context.Persons.FirstOrDefault(st => st.Id == personId).DateOfDeath - _context.Persons.FirstOrDefault(st => st.Id == personId).DateOfBirthday).TotalDays / 365.2425));
            else
                _context.Persons.FirstOrDefault(st => st.Id == personId).Age = -1;
            await _context.SaveChangesAsync();
        }

        public async Task AgeOfPerson()
        {
            foreach(var Person in _context.Persons)
            {
                if (Person.DateOfBirthday.Year != 0001 && Person.DateOfDeath.Year == 0001)
                    Person.Age = Convert.ToInt32(Math.Truncate((DateTime.Now.Date - Person.DateOfBirthday).TotalDays / 365.2425));
                else if (Person.DateOfBirthday.Year != 0001 && Person.DateOfDeath.Year != 0001)
                    Person.Age = Convert.ToInt32(Math.Truncate((Person.DateOfDeath - Person.DateOfBirthday).TotalDays / 365.2425));
                else
                    Person.Age = -1;
            }
            await _context.SaveChangesAsync();
        }

        [HttpPost]
        public async Task EditPerson(int personId, string Name, string OriginalName,
           string RolesInMedia, double Height, string Image, DateTime DateOfBirthday, DateTime DateOfDeath, string PlaceOfBirthday,
           string PlaceOfDeath, string Spouse, string Awards, string Description)
        {
            if(Name != null)
            {
                _context.Persons.FirstOrDefault(st=>st.Id == personId).Name = Name;
            }
            if (OriginalName != null)
            {
                _context.Persons.FirstOrDefault(st => st.Id == personId).OriginalName = OriginalName;
            }
            if (RolesInMedia != null)
            {
                _context.Persons.FirstOrDefault(st => st.Id == personId).RolesInMedia = RolesInMedia;
            }
            if (Height != 0)
            {
                _context.Persons.FirstOrDefault(st => st.Id == personId).Height = Height;
            }
            if (Image != null)
            {
                _context.Persons.FirstOrDefault(st => st.Id == personId).Image = Image;
            }
            if (DateOfBirthday.Year != 0001)
            {
                _context.Persons.FirstOrDefault(st => st.Id == personId).DateOfBirthday = DateOfBirthday;
            }
            if (DateOfDeath.Year != 0001)
            {
                _context.Persons.FirstOrDefault(st => st.Id == personId).DateOfDeath = DateOfDeath;
            }
            if (PlaceOfBirthday != null)
            {
                _context.Persons.FirstOrDefault(st => st.Id == personId).PlaceOfBirthday = PlaceOfBirthday;
            }
            if (PlaceOfDeath != null)
            {
                _context.Persons.FirstOrDefault(st => st.Id == personId).PlaceOfDeath = PlaceOfDeath;
            }
            if (Spouse != null)
            {
                _context.Persons.FirstOrDefault(st => st.Id == personId).Spouse = Spouse;
            }
            if (Awards != null)
            {
                _context.Persons.FirstOrDefault(st => st.Id == personId).Awards = Awards;
            }
            if (Description != null)
            {
                _context.Persons.FirstOrDefault(st => st.Id == personId).Description = Description;
            }

            await _context.SaveChangesAsync();
        }
    }
}
