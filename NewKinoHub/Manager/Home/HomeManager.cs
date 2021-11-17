using KinoHab.Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewKinoHub.Manager.Persons;
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
        public (List<Media>, List<Media>,List<Media>) GetNewPopularFilms(string Email)
        {
            var films = from x in _context.Media.Where(st => st.MediaType == MediaType.Film).Include(st => st.Genres) select x;
            var serials = from x in _context.Media.Where(st =>st.MediaType == MediaType.Serial).Include(st => st.Genres) select x;
            films = films.Where(x => x.Year == 2021 || x.Year == 2020);
            serials = serials.Where(x => x.Year == 2021 || x.Year == 2020);

            films = films.OrderByDescending(st => st.Score);
            serials = serials.OrderByDescending(st => st.Score);

            (List<Media>, List<Media>, List<Media>) media = (films.ToList(), serials.ToList(),null);
            
            return media;
        }

        [HttpGet]
        public async Task<(List<Media>, List<Media>,List<Person>)> Search(string Name, Users User)
        {
            IFilmManager Film = new FilmManager(_context);
            IPersonManager Person = new PersonManager(_context);
            var films = await Film.GetAllFilms();
            var serials = await Film.GetAllFilms();
            var persons = await Person.GetPersons();
            if (User != null && User.Favorites != null)
            {
                films = await Film.GetFilms(User);
                serials = await Film.GetFilms(User);
            }
            (List<Media>, List<Media>,List<Person>) film = (null, null,null); 
            if (!String.IsNullOrEmpty(Name) && Name!= "")
            {
                films = films.Where(x => x.Name.ToLower().Contains(Name.ToLower()) && x.MediaType == MediaType.Film).ToList();
                serials = serials.Where(x => x.Name.ToLower().Contains(Name.ToLower()) && x.MediaType == MediaType.Serial).ToList();
                persons = persons.Where(x => x.Name.ToLower().Contains(Name.ToLower())).ToList();
                
                film = (films.ToList(), serials.ToList(),persons.ToList());
            }
            return film;
        }
        public List<Media> Recommendation(Users User)
        {
            int[] Recommend = new int[21];
            List<Media> Films = new List<Media>();
            
            foreach(var f in _context.Users.FirstOrDefault(st=>st.UserId == User.UserId).Favorites.Medias)
            {
                foreach(var Genre in f.Genres)
                {
                    Recommend[Genre.GenreId]++;
                }
            }

            while (Films.Count <= 3)
            {
                int index = 0;
                int? max = null;
                for (var i = 0; i < Recommend.Length; i++)
                {
                    int thisNum = Recommend[i];
                    if (!max.HasValue || thisNum > max.Value)
                    {
                        max = thisNum;
                        index = i;
                    }
                }
                if (index != 0)
                {
                    foreach (var f in _context.Genres.FirstOrDefault(st => st.GenreId == index).Medias)
                    {
                        if(_context.Favorites.FirstOrDefault(st=>st.UserName == User.Email).Medias.FirstOrDefault(st=>st.MediaID == f.MediaID) == null)
                        {
                            if(Films.FirstOrDefault(st=>st.MediaID == f.MediaID) == null)
                            {
                                Films.Add(f);
                            }
                        }
                    }
                }
                Recommend[index] = 0;
                int Exit = Recommend.Max<int>();
                if(Exit == 0)
                {
                    return Films;
                }
            }
            return Films;
        }
    }
}
