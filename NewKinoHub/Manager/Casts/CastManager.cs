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
        public async Task<Cast> GetCastforId(int castId)
        {
            return _context.Casts.Include(st=>st.Person).FirstOrDefault(st => st.Id == castId);
        }
    }
}
