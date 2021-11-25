using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewKinoHub.Storage;
using NewKinoHub.Storage.Entity;
using System;
using System.IO;
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

        public async Task<ICollection<Person>> GetPersons(int role)
        {
            switch (role)
            {
                case 0:
                    return await _context.Persons.Where(st => st.IsDirector == true).ToListAsync();

                case 1:
                    return await _context.Persons.Where(st => st.IsScreenWriter == true).ToListAsync();

                case 2:
                    return await _context.Persons.Where(st => st.IsActor == true).ToListAsync();

                default:
                    return await _context.Persons.ToListAsync();
            }
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
           bool IsActor, bool IsScreenWriter, bool IsDirector, double Height, IFormFile mainPhoto, DateTime DateOfBirthday, DateTime DateOfDeath, string PlaceOfBirthday,
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
            _context.Persons.FirstOrDefault(st => st.Id == personId).IsActor = IsActor;
            _context.Persons.FirstOrDefault(st => st.Id == personId).IsScreenWriter = IsScreenWriter;
            _context.Persons.FirstOrDefault(st => st.Id == personId).IsDirector = IsActor;            
            if (Height != 0)
            {
                _context.Persons.FirstOrDefault(st => st.Id == personId).Height = Height;
            }
            if (mainPhoto != null)
            {
                _context.Persons.FirstOrDefault(st => st.Id == personId).Img = SaveImage.getByteImage(mainPhoto);
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

        public async Task<ICollection<Person>> AllSorting(string sort)
        {
            var persons = await GetPersons();

            switch (sort)
            {
                case "YearOld":
                    persons = persons.OrderBy(st => st.DateOfBirthday).ToList();
                    break;
                case "YearNew":
                    persons = persons.OrderByDescending(st => st.DateOfBirthday).ToList();
                    break;
                case "NameA":
                    persons = persons.OrderBy(st => st.Name).ToList();
                    break;
                case "NameZ":
                    persons = persons.OrderByDescending(st => st.Name).ToList();
                    break;

            }
            return persons;
        }

        public async Task<List<Person>> Filtration(string Actors, string Directors, string ScreenWriter)
        {
            List<Person> Persons = await _context.Persons.ToListAsync();
            if (Actors != null)
            {
                Persons = Persons.Where(st => st.IsActor == true).ToList();
            }
            if(Directors != null)
            {
                Persons = Persons.Where(st => st.IsDirector == true).ToList();
            }
            if(ScreenWriter != null)
            {
                Persons = Persons.Where(st => st.IsScreenWriter == true).ToList();
            }
            return Persons;
        }

        public List<Person> SortingFromFiltr(string sort, List<Person> Filtr)
        {
            switch (sort)
            {
                case "YearOld":
                    Filtr = Filtr.OrderBy(st => st.DateOfBirthday).ToList();
                    break;
                case "YearNew":
                    Filtr = Filtr.OrderByDescending(st => st.DateOfBirthday).ToList();
                    break;
                case "NameA":
                    Filtr = Filtr.OrderBy(st => st.Name).ToList();
                    break;
                case "NameZ":
                    Filtr = Filtr.OrderByDescending(st => st.Name).ToList();
                    break;
            }
            return Filtr;
        }

        public string GetPersonName(int IdPerson)
        {
            return _context.Persons.FirstOrDefault(st => st.Id == IdPerson).Name;
        }


        [HttpPost]
        public async Task AddPerson(string Name, string OriginalName,
            string IsActor, string IsScreenWriter, string IsDirector, double Height, IFormFile mainPhoto, DateTime DateOfBirthday, DateTime DateOfDeath, string PlaceOfBirthday,
            string PlaceOfDeath, string Spouse, string Awards, string Description)
        {
            Person person = new()
            {
                Name = Name,
                OriginalName = OriginalName,
                IsActor = IsActor != null,
                IsDirector = IsDirector != null,
                IsScreenWriter = IsScreenWriter != null,
                Height = Height,
                Img = mainPhoto != null ? SaveImage.getByteImage(mainPhoto) : File.ReadAllBytes(@"wwwroot\lib\images\trav1.gif"),
                DateOfBirthday = DateOfBirthday,
                DateOfDeath = DateOfDeath,
                PlaceOfBirthday = PlaceOfBirthday,
                PlaceOfDeath = PlaceOfDeath,
                Spouse = Spouse,
                Awards = Awards,
                Description = Description
            };
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
        }
    }
}
