using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewKinoHub.Storage;
using NewKinoHub.Storage.Entity;
using System;
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
                                 .Include(st => st.Genres)
                                 .Include(st => st.Casts)
                                 .ThenInclude(st => st.Person)
                                 .ToListAsync();
        }

        public async Task<ICollection<Media>> GetFavoriteFilmsForUser(Users User)
        {
            List<Media> FavoritesFilms = null;
            if (User != null && User.Favorites!= null)
            {
                FavoritesFilms = User.Favorites.Medias;
                return FavoritesFilms;
            }
            return FavoritesFilms;
        }

        public async Task<ICollection<Media>> GetViewedFilmsForUser(Users User)
        {
            List<Media> ViewedFilms = null;
            if (User != null && User.Viewed != null)
            {
                ViewedFilms = User.Viewed.Medias;
                return ViewedFilms;
            }
            return ViewedFilms;
        }
        public async Task<ICollection<Media>> GetFilms(Users User)
        {
            var Films = await GetAllFilms();
            if (User != null && User.Favorites != null)
            {
                var FavoritFilm = await GetFavoriteFilmsForUser(User);
                foreach (var f in Films)
                {
                    foreach (var Fav in FavoritFilm)
                    {
                        if (f.MediaID == Fav.MediaID)
                        {
                            f.IsFavorites = true;
                        }
                    }
                }
            }

            if (User != null && User.Viewed != null)
            {
                var ViewedFilm = await GetViewedFilmsForUser(User);
                foreach (var f in Films)
                {
                    foreach (var Fav in ViewedFilm)
                    {
                        if (f.MediaID == Fav.MediaID)
                        {
                            f.IsVieweds = true;
                        }
                    }
                }
            }
            return Films;
        }

        public async Task<Media> GetIdFilms(int filmId, Users User)
        {
            var Films = _context.Media
                                .Include(st => st.Genres)
                                .FirstOrDefault(st => st.MediaID == filmId);
            if (User != null  && User.Favorites != null)
            {
                var FavoritFilm = await GetFavoriteFilmsForUser(User);
                foreach (var Fav in FavoritFilm)
                {
                    if (Films.MediaID == Fav.MediaID)
                    {
                        Films.IsFavorites = true;
                    }
                }
                
            }
            if (User != null && User.Viewed != null)
            {
                var FavoritFilm = await GetViewedFilmsForUser(User);
                foreach (var Fav in FavoritFilm)
                {
                    if (Films.MediaID == Fav.MediaID)
                    {
                        Films.IsVieweds = true;
                    }
                }

            }
            return Films;
        }
        public async Task<Users> GetUser(string UserEmail)
        {
            return await _context.Users
                                 .Include(st => st.Favorites)
                                 .ThenInclude(st=>st.Medias)
                                 .Include(st => st.Viewed)
                                 .ThenInclude(st => st.Medias)
                                 .FirstOrDefaultAsync(st => st.Email == UserEmail);
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
            return role;
        }

        public MediaType TypeFilm(string i)
        {
            MediaType role = MediaType.Film;
            if (i == "Serial")
            {
                role = MediaType.Serial;
                return role;
            }
            return role;
        }

        public async Task<Media> GetFilmforId(int filmId, Users User)
        {
            var Images = _context.MediaImages.Where(st => st.MediaId == filmId).ToList();
            _context.Media.FirstOrDefault(st => st.MediaID == filmId).Images = Images;
            var Casts = _context.Casts.Where(st => st.MediaId == filmId).ToList();

            foreach(var c in Casts)
            {
               foreach(var p in _context.Persons)
                {
                    if(c.PersonId == p.Id)
                    {
                        c.Person = p;
                    }
                } 
            }
            _context.Media.FirstOrDefault(st => st.MediaID == filmId).Casts = Casts;
            var Reviews = _context.Reviews.Where(st => st.MediaId == filmId).ToList();
            _context.Media.FirstOrDefault(st => st.MediaID == filmId).Reviews = Reviews;
            if (User != null && User.Favorites != null)
            {
                var Films = await GetIdFilms(filmId,User);
                return Films;
            }
            return  _context.Media
                            .Include(st => st.Genres)
                            .FirstOrDefault(st => st.MediaID == filmId);
        }

         public async Task<ICollection<Media>> AllSorting(string sort, Users User)
         {
            var media = await GetAllFilms();
            if(User != null && User.Favorites != null) 
            {
                media = await GetFilms(User);
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

         public async Task<ICollection<Media>> Filtration(int filtr, Users User)
         {

            var media = await GetAllFilms();
            if (User != null && User.Favorites != null)
            {
                media = await GetFilms(User);
            }

            List<Media> film = new List<Media>();
            bool p = false;
            foreach(var f in media)
            {
                foreach(var f1 in f.Genres)
                {
                    if (f1.NumOfGenre == filtr)
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
            foreach (var f in genres.Where(st=>st.NumOfGenre == idFiltr))
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

        public async Task DeleteFilm(int IdFIlm)
        {
            var itemToRemove = await _context.Media.Include(st=>st.Casts)
                                                   .ThenInclude(st=>st.Person)
                                                   .Include(st=>st.Images)
                                                   .Include(st=>st.Genres)
                                                   .Include(st=>st.Reviews)
                                                   .SingleOrDefaultAsync(st => st.MediaID == IdFIlm);

            if (itemToRemove != null)
            {
                _context.Media.Remove(itemToRemove);
            }

            await _context.SaveChangesAsync();
        }

        [HttpPost]
        public async Task AddFilm(string mainPhoto, string Name, int Year, string Contry, string Release_Date, int Age, string RunTime, string Description, string shortDiscription, double Score, string ScoreKP,string Music, string Video)
        {
            Media Film = new Media();
            Film.Img = mainPhoto;           
            Film.Name = Name;       
            Film.Year = Year;         
            Film.Country = Contry;                   
            Film.Release_Date = Release_Date;                      
            Film.Age = Age;                    
            Film.Runtime = RunTime;                      
            Film.Description = Description;                  
            Film.ShortDescription = shortDiscription;
            Film.Score = Score;
            Film.ScoreKP = ScoreKP;
            Film.Video = Video;
            Film.SoundTrackUrl = Music;

            _context.Media.Add(Film);
            await _context.SaveChangesAsync();
        }

        public async Task EditFilm(string mainPhoto, string Name, int Year, string Contry, string Release_Date, int Age, string RunTime, string Description, string shortDescription, double Score, string ScoreKP, string Music, string Video, int id)
        {
            if (mainPhoto != null)
            {
                _context.Media.FirstOrDefault(st => st.MediaID == id).Img = mainPhoto;
            }
            if (Name != null)
            {
                _context.Media.FirstOrDefault(st => st.MediaID == id).Name = Name;
            }
            if (Year != 0)
            {
                _context.Media.FirstOrDefault(st => st.MediaID == id).Year = Year;
            }
            if (Contry != null)
            {
                _context.Media.FirstOrDefault(st => st.MediaID == id).Country = Contry;
            }
            if (Release_Date != null)
            {
                _context.Media.FirstOrDefault(st => st.MediaID == id).Release_Date = Release_Date;
            }
            if (Age != 0)
            {
                _context.Media.FirstOrDefault(st => st.MediaID == id).Age = Age;
            }
            if (RunTime != null)
            {
                _context.Media.FirstOrDefault(st => st.MediaID == id).Runtime = RunTime;
            }
            if (Description != null)
            {
                _context.Media.FirstOrDefault(st => st.MediaID == id).Description = Description;
            }
            if (shortDescription != null)
            {
                _context.Media.FirstOrDefault(st => st.MediaID == id).ShortDescription = shortDescription;
            }
            if (Score != 0)
            {
                _context.Media.FirstOrDefault(st => st.MediaID == id).Score = Score;
            }
            if (ScoreKP != null)
            {
                _context.Media.FirstOrDefault(st => st.MediaID == id).ScoreKP = ScoreKP;
            }
            if (Music != null)
            {
                _context.Media.FirstOrDefault(st => st.MediaID == id).SoundTrackUrl = Music;
            }
            if (Video != null)
            {
                _context.Media.FirstOrDefault(st => st.MediaID == id).Video = Video;
            }
            await _context.SaveChangesAsync();
        }

        [HttpPost]
        public async  Task AddReviews(int idFilm, string Email, string text)
        {
            var NickName = _context.Users.FirstOrDefault(st => st.Email == Email).Nickname;
            Review review = new Review();
            review.Description = text;
            review.MediaId = idFilm;
            review.UsersId = _context.Users.FirstOrDefault(st => st.Email == Email).UserId;
            review.Nickname = NickName;
            review.DateOfReview = DateTime.Now.ToString();
            _context.Media.FirstOrDefault(st => st.MediaID == idFilm).Reviews.Add(review);
            await _context.SaveChangesAsync();
        }
    }
}
