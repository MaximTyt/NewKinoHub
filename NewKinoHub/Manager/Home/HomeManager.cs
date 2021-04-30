using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewKinoHub.Storage;
using NewKinoHub.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewKinoHub.Manager.Home
{
    public class HomeManager : IHomeManager
    {
        private readonly MvcFilmContext _context;
        public HomeManager(MvcFilmContext context)
        {
            _context = context;
        }
        public (List<Media>, List<Media>) GetNewPopularFilms()
        {
            var films = from x in _context.Media.Where(st => st.MediaType == MediaType.Film).Include(st => st.Genres) select x;
            var serials = from x in _context.Media.Where(st =>st.MediaType == MediaType.Serial).Include(st => st.Genres) select x;
            films = films.Where(x => x.Year == 2021 || x.Year == 2020);
            serials = serials.Where(x => x.Year == 2021 || x.Year == 2020);

            films = films.OrderByDescending(st => st.Score);
            serials = serials.OrderByDescending(st => st.Score);
            (List<Media>, List<Media>) media = (films.ToList(), serials.ToList());

            return media;
        }

        [HttpGet]
        public (List<Media>, List<Media>) Search(string Name)
        {
            var films = from x in _context.Media.Include(st => st.Genres) select x;
            var serials = from x in _context.Media.Include(st => st.Genres) select x;
            if (!String.IsNullOrEmpty(Name))
            {
                films = films.Where(x => x.Name.Contains(Name) && x.MediaType == MediaType.Film);
                serials = serials.Where(x => x.Name.Contains(Name) && x.MediaType == MediaType.Serial);
            }
            (List<Media>, List<Media>) film = (films.ToList(), serials.ToList());
            return film;
        }
    }
}
