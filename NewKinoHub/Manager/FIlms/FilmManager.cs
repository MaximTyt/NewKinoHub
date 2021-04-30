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
            return await _context.Media.Where(st => st.MediaType == MediaType.Film).Include(st => st.Genres).ToListAsync();
        }

        public async Task<Media> GetFilmforId(int filmId)
        {
            return  _context.Media.Include(st => st.Genres).FirstOrDefault(st => st.MediaID == filmId);
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
