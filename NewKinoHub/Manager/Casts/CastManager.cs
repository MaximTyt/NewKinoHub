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

        public  async Task<ICollection<Cast>> GetAllCast(int castId)
        {
            return await _context.Casts.Include(st => st.Person).Where(st=>st.Media.MediaID == castId && st.RoleInFilm == RoleInFilm.Actor).ToListAsync();
        }

        public async Task<Cast> GetPersonforId(int personId)
        {
            return await _context.Casts.Include(st=>st.Person).FirstOrDefaultAsync(st => st.Id == personId);
        }

        public RoleInFilm Cast(int i)
        {
            RoleInFilm role = RoleInFilm.Actor;
            if (i == 0)
            {
                role = RoleInFilm.Director;
                return role;
            }
            if (i == 1)
            {
                role = RoleInFilm.Screenwriter;
                return role;
            }
            if (i == 2)
            {
                role = RoleInFilm.Actor;
                return role;
            }
            return role;
        }
    }
}
