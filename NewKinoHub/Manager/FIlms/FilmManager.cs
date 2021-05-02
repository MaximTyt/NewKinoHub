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
            return await _context.Media.Where(st => st.MediaType == MediaType.Film).Include(st => st.Genres).Include(st => st.Casts).ThenInclude(st => st.Person).ToListAsync();
        }

        public async Task<ICollection<Media>> GetAllSerials()
        {
            return await _context.Media.Where(st => st.MediaType == MediaType.Serial).Include(st => st.Genres).Include(st => st.Casts).ThenInclude(st => st.Person).ToListAsync();
        }

        public RoleInFilm Cast(int i)
        {
            RoleInFilm role = RoleInFilm.Actor;
            if(i == 0)
            {
                role = RoleInFilm.Director;
                return role;
            }
            if(i == 1)
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

        public async Task<Media> GetFilmforId(int filmId)
        {
            return  _context.Media.Include(st => st.Genres).Include(st=>st.Images).Include(st=>st.Casts).ThenInclude(st=>st.Person).FirstOrDefault(st => st.MediaID == filmId);
        }

        public Media GetSerialforId(int serialId)
        {
            var serial = _context.Media.Include(st => st.Genres).FirstOrDefault(st => st.MediaID == serialId);
            return serial;
        }


        // public ICollection<Media> AllSorting(string sort)
        // {
        //     var film = _context.Films.Include(st=>st.Genres).ToList();
        //     if (sort == "YearOld")
        //     {
        //         film = _context.Films.OrderBy(st => st.Year).ToList();
        //     }
        //     if(sort == "YearNew")
        //     {
        //         film = _context.Films.OrderByDescending(st => st.Year).ToList();
        //     }
        //     if(sort == "Score")
        //     {
        //         film = _context.Films.OrderByDescending(st => st.Score).ToList();
        //     }
        //     if (sort == "NameA")
        //     {
        //         film = _context.Films.OrderBy(st => st.Name).ToList();
        //     }
        //     if (sort == "NameZ") 
        //     {
        //         film = _context.Films.OrderByDescending(st => st.Name).ToList();
        //     }
        //     return film;
        // }

        // public ICollection<Media> SortingForFiltr(string sort, ICollection<Film> films)
        // {
        //     var film = films;
        //     if (sort == "YearOld")
        //     {
        //         film = _context.Films.OrderBy(st => st.Year).ToList();
        //     }
        //     if (sort == "YearNew")
        //     {
        //         film = _context.Films.OrderByDescending(st => st.Year).ToList();
        //     }
        //     if (sort == "Score")
        //     {
        //         film = _context.Films.OrderByDescending(st => st.Score).ToList();
        //     }
        //     if (sort == "NameA")
        //     {
        //         film = _context.Films.OrderBy(st => st.Name).ToList();
        //     }
        //     if (sort == "NameZ")
        //     {
        //         film = _context.Films.OrderByDescending(st => st.Name).ToList();
        //     }
        //     return film;
        // }

        // public ICollection<Media> Filtration(int filtr)
        // {
        //     var film = _context.Films.Include(st => st.Genres).ToList();
        //     List<Film> film2 = new List<Film>();
        //     bool p = false;
        //     foreach(var f in film)
        //     {
        //         foreach(var f1 in f.Genres)
        //         {
        //             if (f1.GenreID == filtr)
        //             {
        //                 p = true;
        //             }
        //         }
        //         if(p == true)
        //             film2.Add(f);
        //         p = false;
        //     }
        //     return film2;
        // }
    }
}
