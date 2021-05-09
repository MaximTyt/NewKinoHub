using Microsoft.EntityFrameworkCore;
using NewKinoHub.Storage;
using NewKinoHub.Storage.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinoHab.Manager
{
    public class FilmManager : IFilmManager
    {
        private readonly MvcFilmContext _context;
        public FilmManager(MvcFilmContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Media>> GetAllFilms()
        {
            return await _context.Media
                                 .Where(st => st.MediaType == MediaType.Film)
                                 .Include(st => st.Genres)
                                 .Include(st => st.Casts)
                                 .ThenInclude(st => st.Person)                                 
                                 .ToListAsync();
        }

        public async Task<ICollection<Media>> GetAllSerials()
        {
            return await _context.Media
                                 .Where(st => st.MediaType == MediaType.Serial)
                                 .Include(st => st.Genres)
                                 .Include(st => st.Casts)
                                 .ThenInclude(st => st.Person)                                 
                                 .ToListAsync();
        }

        public RoleInFilm Cast(int i)
        {
            RoleInFilm role = RoleInFilm.Актёр;
            if(i == 0)
            {
                role = RoleInFilm.Режиссёр;
                return role;
            }
            if(i == 1)
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

        public async Task<Media> GetFilmforId(int filmId)
        {
            return await _context.Media.Include(st => st.Genres)
                                       .Include(st=>st.Images)
                                       .Include(st=>st.Casts)
                                       .ThenInclude(st=>st.Person)                                       
                                       .FirstOrDefaultAsync(st => st.MediaID == filmId);
        }

         public async Task<ICollection<Media>> AllSorting(string sort,string type)
         {
            var media = await _context.Media
                                      .Include(st => st.Genres)
                                      .Include(st => st.Casts)
                                      .ThenInclude(st => st.Person)
                                      .ToListAsync();

            if(type == "Film")
            {
                media = await _context.Media
                                      .Where(st=>st.MediaType == MediaType.Film)
                                      .Include(st => st.Genres)
                                      .Include(st => st.Casts)
                                      .ThenInclude(st => st.Person)
                                      .ToListAsync();
            }

            if(type == "Serial")
            {
                media = await _context.Media
                                      .Where(st => st.MediaType == MediaType.Serial)
                                      .Include(st => st.Genres)
                                      .Include(st => st.Casts)
                                      .ThenInclude(st => st.Person)
                                      .ToListAsync();
            }

            if (sort == "YearOld")
            {
                media = media.OrderBy(st => st.Year).ToList();
            }
            if (sort == "YearNew")
            {
                media =  media.OrderByDescending(st => st.Year).ToList();
            }
            if (sort == "Score")
            {
                media = media.OrderByDescending(st => st.Score).ToList();
            }
            if (sort == "NameA")
            {
                media = media.OrderBy(st => st.Name).ToList();
            }
            if (sort == "NameZ")
            {
                media = media.OrderByDescending(st => st.Name).ToList();
            }
            return media;
         }

         public async Task<ICollection<Media>> Filtration(int filtr, string type)
         {

            var media = await _context.Media
                                      .Include(st => st.Genres)
                                      .Include(st => st.Casts)
                                      .ThenInclude(st => st.Person)                                      
                                      .ToListAsync();

            if (type == "Film")
            {
                media = await _context.Media
                                      .Where(st => st.MediaType == MediaType.Film)
                                      .Include(st => st.Genres)
                                      .Include(st => st.Casts)
                                      .ThenInclude(st => st.Person)                                      
                                      .ToListAsync();
            }

            if (type == "Serial")
            {
                media = await _context.Media
                                      .Where(st => st.MediaType == MediaType.Serial)
                                      .Include(st => st.Genres)
                                      .Include(st => st.Casts)
                                      .ThenInclude(st => st.Person)                                      
                                      .ToListAsync();
            }

            List<Media> film = new List<Media>();
            bool p = false;
            foreach(var f in media)
            {
                foreach(var f1 in f.Genres)
                {
                    if (f1.GenreId == filtr)
                    {
                        p = true;
                    }
                }
                if(p == true)
                    film.Add(f);
                p = false;
            }

            return film;
         }

        public string GetNameFiltr(int idFiltr)
        {
            var genres = _context.Genres;
            string Name = null;
            foreach (var f in genres.Where(st=>st.GenreId == idFiltr))
            {
                Name = f.Genre_Name;
            }
            return Name;
        }

        public async Task<ICollection<Media>> SortingFromFiltr(string sort, ICollection<Media> media)
        {
            if (sort == "YearOld")
            {
                media = media.OrderBy(st => st.Year).ToList();
            }
            if (sort == "YearNew")
            {
                media = media.OrderByDescending(st => st.Year).ToList();
            }
            if (sort == "Score")
            {
                media = media.OrderByDescending(st => st.Score).ToList();
            }
            if (sort == "NameA")
            {
                media = media.OrderBy(st => st.Name).ToList();
            }
            if (sort == "NameZ")
            {
                media = media.OrderByDescending(st => st.Name).ToList();
            }
            return media;
        }
    }
}
