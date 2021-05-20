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

        public async Task<ICollection<Cast>> GetAllCast(int castId)
        {
            return await _context.Casts.Include(st => st.Person).Where(st => st.Media.MediaID == castId && st.RoleInFilm == RoleInFilm.Актёр).ToListAsync();
        }

        public async Task<Cast> GetPersonforId(int personId)
        {
            return await _context.Casts.Include(st => st.Person).FirstOrDefaultAsync(st => st.Id == personId);
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
        public async Task AgeOfPerson(int personId)
        {
            if (_context.Casts.FirstOrDefault(st => st.Id == personId).Person.DateOfBirthday.Year !=0001 && _context.Casts.FirstOrDefault(st => st.Id == personId).Person.DateOfDeath.Year == 0001)
                _context.Casts.FirstOrDefault(st => st.Id == personId).Person.Age = Convert.ToInt32(Math.Truncate((DateTime.Now.Date - _context.Casts.FirstOrDefault(st => st.Id == personId).Person.DateOfBirthday).TotalDays / 365.2425));
            else if (_context.Casts.FirstOrDefault(st => st.Id == personId).Person.DateOfBirthday.Year != 0001 && _context.Casts.FirstOrDefault(st => st.Id == personId).Person.DateOfDeath.Year != 0001)
                _context.Casts.FirstOrDefault(st => st.Id == personId).Person.Age = Convert.ToInt32(Math.Truncate((_context.Casts.FirstOrDefault(st => st.Id == personId).Person.DateOfDeath - _context.Casts.FirstOrDefault(st => st.Id == personId).Person.DateOfBirthday).TotalDays / 365.2425));
            else
                _context.Casts.FirstOrDefault(st => st.Id == personId).Person.Age = -1;
            await _context.SaveChangesAsync();
        }
    }
}
