using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewKinoHub.Storage;
using NewKinoHub.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewKinoHub.Manager.Casts
{
    public class CastManager : ICastManager
    {
        private readonly MvcFilmContext _context;
        public CastManager(MvcFilmContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Cast>> GetAllActors(int FilmId)
        {
            return await _context.Casts.Include(st => st.Person)
                                       .Where(st => st.MediaId == FilmId && st.RoleInFilm == RoleInFilm.Актёр)
                                       .ToListAsync();
        }

        public async Task<ICollection<Cast>> GetAllCast(int FilmId)
        {
            return await _context.Casts.Include(st => st.Person)
                                       .Where(st => st.MediaId == FilmId)
                                       .ToListAsync();
        }

        public async Task<Person> GetPersonforId(int personId)
        {
            return await _context.Persons
                                 .FirstOrDefaultAsync(st => st.Id == personId);
        }

        public RoleInFilm Cast(int i)
        {
            RoleInFilm role = RoleInFilm.Актёр;
            if (i == 0)
            {
                role = RoleInFilm.Режиссёр;
                return role;
            }
            if (i == 1)
            {
                role = RoleInFilm.Сценарист;
                return role;
            }
            if (i == 2)
            {
                role = RoleInFilm.Актёр;
                return role;
            }
            return role;
        }        

        [HttpPost]
        public async Task AddCast(int IdFilm, string Character, int RoleInFilm, string Name, string OriginalName, 
            string RolesInMedia, double Height,string Image,DateTime DateOfBirthday, DateTime DateOfDeath,string PlaceOfBirthday,
            string PlaceOfDeath,string Spouse,string Awards,string Description)
        {
            Cast Cast = new Cast
            {
                MediaId = IdFilm,
                Character = Character,
                RoleInFilm = (RoleInFilm)RoleInFilm 
            };
            Person person = new Person()
            {
                Name = Name,
                OriginalName = OriginalName,
                RolesInMedia = RolesInMedia,
                Height = Height,
                Image = Image,
                DateOfBirthday = DateOfBirthday,
                DateOfDeath = DateOfDeath,
                PlaceOfBirthday = PlaceOfBirthday,
                PlaceOfDeath = PlaceOfDeath,
                Spouse = Spouse,
                Awards = Awards,
                Description = Description
            };
            
            Cast.Person = person;
            _context.Casts.Add(Cast);
            await _context.SaveChangesAsync();
        }

        [HttpPost]
        public async Task EditCast(int IdCast,int IdFilm, string Character, int RoleInFilm)
        {
            if(Character != null)
            {
                _context.Casts.FirstOrDefault(st => st.Id == IdCast && st.MediaId == IdFilm).Character = Character;
            }

            _context.Casts.FirstOrDefault(st => st.Id == IdCast).RoleInFilm = (RoleInFilm)RoleInFilm;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCast(int IdCast)
        {
            var itemToRemove = await _context.Casts
                                             .FirstOrDefaultAsync(st => st.Id == IdCast);
            if (itemToRemove != null)
            {
                _context.Casts.Remove(itemToRemove);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Cast> GetCastForId(int IdCast,int IdFilm)
        {
            return await _context.Casts.FirstOrDefaultAsync(st => st.Id == IdCast && st.MediaId == IdFilm);
        }

        [HttpPost]
        public List<Person> Search(string Name)
        {
            List<Person> person = _context.Persons.ToList();
            if (!String.IsNullOrEmpty(Name) && Name != "")
            {
                person = person.Where(x => x.Name.Contains(Name)).ToList();
            }
            return person;
        }

        public async Task AddSearchPerson(int IdFilm, int IdPerson, int role)
        {
            Cast Cast = new Cast
            {
                Person = await _context.Persons.FirstOrDefaultAsync(st => st.Id == IdPerson),
                MediaId = IdFilm,
                PersonId = IdPerson,
                RoleInFilm = (RoleInFilm)role
                
            };
            _context.Media.FirstOrDefault(st => st.MediaID == IdFilm).Casts.Add(Cast);
            await _context.SaveChangesAsync();
        }
    }
}
