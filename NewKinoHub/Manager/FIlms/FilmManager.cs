using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewKinoHub.Storage;
using NewKinoHub.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using NewKinoHub.Models;
using NewKinoHub.Manager;
using Microsoft.AspNetCore.Http;
using System.IO;

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


            var Films = _context.Media.Include(st => st.Genres);
            foreach (var f in Films)
            {
                var Casts = await _context.Casts.Where(st => st.MediaId == f.MediaID).ToListAsync();

                foreach (var c in Casts)
                {
                    foreach (var p in _context.Persons)
                    {
                        if (c.PersonId == p.Id)
                        {
                            c.Person = p;
                        }
                    }
                }
                f.Casts = Casts;
            }

            return await Films.ToListAsync();

        }

        public ICollection<Media> GetFavoriteFilmsForUser(Users User)
        {
            List<Media> FavoritesFilms = null;
            if (User != null && User.Favorites!= null)
            {
                FavoritesFilms = User.Favorites.Medias;
                return FavoritesFilms;
            }
            return FavoritesFilms;
        }

        public ICollection<Media> GetViewedFilmsForUser(Users User)
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
                var FavoritFilm = GetFavoriteFilmsForUser(User);
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
                var ViewedFilm = GetViewedFilmsForUser(User);
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


            var Films = await _context.Media
                                      .Include(st => st.Genres)
                                      .FirstOrDefaultAsync(st => st.MediaID == filmId);

            var Images = _context.MediaImages.Where(st => st.MediaId == filmId).ToList();
            Films.Images = Images;

            var Casts = _context.Casts.Where(st => st.MediaId == filmId).ToList();

            foreach (var c in Casts)
            {
                foreach (var p in _context.Persons)
                {
                    if (c.PersonId == p.Id)
                    {
                        c.Person = p;
                    }
                }
            }

            Films.Casts = Casts;

            if (User != null  && User.Favorites != null)
            {
                var FavoritFilm = GetFavoriteFilmsForUser(User);
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
                var FavoritFilm = GetViewedFilmsForUser(User);
                foreach (var Fav in FavoritFilm)
                {
                    if (Films.MediaID == Fav.MediaID)
                    {
                        Films.IsVieweds = true;
                    }
                }

            }

            var Reviews = _context.Reviews.Where(st => st.MediaId == filmId).ToList();
            foreach (var r in Reviews)
            {
                foreach (var us in _context.Users)
                {
                    if (r.UsersId == us.UserId)
                    {
                        r.ImgUser = us.Image;
                    }
                }
            }
            Films.Reviews = Reviews;
            return Films;
        }
        public async Task<Users> GetUser(string UserEmail)
        {
            if (UserEmail != null)
            {
                var User = await _context.Users.FirstOrDefaultAsync(st => st.Email == UserEmail);
                var Favorites = await _context.Favorites.Include(st => st.Medias).FirstOrDefaultAsync(st => st.UserName == UserEmail);
                User.Favorites = Favorites;
                var Vieweds = await _context.Vieweds.Include(st => st.Medias).FirstOrDefaultAsync(st => st.UserName == UserEmail);
                User.Viewed = Vieweds;
                return User;
            }
            else
            {
                return null;
            }
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

        public bool UserReview(string Email, int IdFilm)
        {
            bool p = false;
            if (Email != null) {
                foreach (var rev in _context.Reviews.Where(st =>st.MediaId == IdFilm))
                {
                    if(rev.UsersId == _context.Users.FirstOrDefault(st=>st.Email == Email).UserId)
                    {
                        p = true;
                    }
                }
            }
            return p;
        }

        public async Task<Media> GetFilmforId(int filmId, Users User)
        {
            if (User != null && User.Favorites != null)
            {
                var Films = await GetIdFilms(filmId, User);
                return Films;
            }

            var Filmss = await _context.Media
                                       .Include(st => st.Genres)
                                       .FirstOrDefaultAsync(st => st.MediaID == filmId);

            var Images = _context.MediaImages.Where(st => st.MediaId == filmId).ToList();
            Filmss.Images = Images;
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

            Filmss.Casts = Casts;
            var Reviews = _context.Reviews.Where(st => st.MediaId == filmId).ToList();

            foreach(var r in Reviews)
            {
                foreach(var us in _context.Users)
                {
                    if(r.UsersId == us.UserId)
                    {
                        r.ImgUser = us.Image;
                    }
                }
            }
            Filmss.Reviews = Reviews;

            return Filmss;
        }
                            

         public async Task<ICollection<Media>> AllSorting(string sort, Users User)
         {
            var media = await GetAllFilms();
            if (User != null && User.Favorites != null)
            {
                media = await GetFilms(User);
            }

            switch (sort)
            {
                case "YearOld":
                    media = media.OrderBy(st => st.Release_Date.Date).ToList();
                    break;
                case "YearNew":
                    media = media.OrderByDescending(st => st.Release_Date.Date).ToList();
                    break;
                case "Score":
                    media = media.OrderByDescending(st => st.Score).ToList();
                    break;
                case "NameA":
                    media = media.OrderBy(st => st.Name).ToList();
                    break;
                case "NameZ":
                    media = media.OrderByDescending(st => st.Name).ToList();
                    break;

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

        public ICollection<Media> SortingFromFiltr(string sort, ICollection<Media> media)
        {
            if (sort == "YearOld")
            {
                media = media.OrderBy(st => st.Release_Date.Date).ToList();
            }
            if (sort == "YearNew")
            {
                media = media.OrderByDescending(st => st.Release_Date.Date).ToList();
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
        public async Task AddFilm(IFormFile mainPhoto, string Name, string Contry, int Age, string RunTime, string Description, string shortDiscription, string Score, string ScoreKP, string Music, string Video, int NumOfEpisodes, int NumOfSeason, int type, 
            IFormFile Images1, IFormFile Images2, IFormFile Images3, IFormFile Images4, string[] genres, DateTime Release_Date)
        {
            Media Film = new Media();
            if (NumOfSeason != 0)
            {
                Film.NumOfSeason = NumOfSeason;
            }
            if (NumOfEpisodes != 0)
            {
                Film.NumOfEpisodes = NumOfEpisodes;
            }
            if (type == 0)
            {
                Film.MediaType = MediaType.Film;
            }
            else
            {
                if (type == 1)
                {
                    Film.MediaType = MediaType.Serial;
                }
            }
            Film.Img = mainPhoto != null ? SaveImage.getByteImage(mainPhoto) : File.ReadAllBytes(@"wwwroot\lib\images\netpostera.png");
            Film.Name = Name;            
            Film.Country = Contry;
            Film.Release_Date = Release_Date;
            Film.Age = Age;
            Film.Runtime = RunTime;
            Film.Description = Description;
            Film.ShortDescription = shortDiscription;
            Film.Score = double.Parse(Score.Replace(',', '.'), new NumberFormatInfo());
            Film.ScoreKP = ScoreKP;
            Film.Video = Video;
            Film.SoundTrackUrl = Music;
            Film.Images = new List<MediaImages>()
            {
                new MediaImages
                 {
                     MediaImage = Images1 != null ? SaveImage.getByteImage(Images1) : File.ReadAllBytes(@"wwwroot\lib\images\loading.gif")
                 },
                 new MediaImages
                 {
                     MediaImage = Images2 != null ? SaveImage.getByteImage(Images2) : File.ReadAllBytes(@"wwwroot\lib\images\loading.gif")
                 },
                 new MediaImages
                 {
                     MediaImage = Images3 != null ? SaveImage.getByteImage(Images3) : File.ReadAllBytes(@"wwwroot\lib\images\loading.gif")
                 },
                 new MediaImages
                 {
                     MediaImage = Images4 != null ? SaveImage.getByteImage(Images4) : File.ReadAllBytes(@"wwwroot\lib\images\loading.gif")
                 }
            };

            foreach(var g in genres)
            {
                Film.Genres.Add(_context.Genres.Include(st => st.Medias).FirstOrDefault(st => st.Genre_Name == g));

            }
            _context.Media.Add(Film);
            await _context.SaveChangesAsync();
        }
                

        [HttpPost]
        public async Task EditFilm(IFormFile mainPhoto, string Name, string Contry, int Age, string RunTime, string Description, string shortDiscription, string Score, string ScoreKP, string Music, string Video, int Id, int NumOfEpisodes, int NumOfSeason, int type, IFormFile Images1, IFormFile Images2, IFormFile Images3, IFormFile Images4, string[] genres, DateTime Release_Date)
        {
            if (mainPhoto != null)
            {
                _context.Media.FirstOrDefault(st => st.MediaID == Id).Img = SaveImage.getByteImage(mainPhoto);
            }
            if (Name != null)
            {
                _context.Media.FirstOrDefault(st => st.MediaID == Id).Name = Name;
            }            
            if (Contry != null)
            {
                _context.Media.FirstOrDefault(st => st.MediaID == Id).Country = Contry;
            }
            if (Release_Date.Year != 0001)
            {
                _context.Media.FirstOrDefault(st => st.MediaID == Id).Release_Date = Release_Date;
            }
            if (Age != 0)
            {
                _context.Media.FirstOrDefault(st => st.MediaID == Id).Age = Age;
            }
            if (RunTime != null)
            {
                _context.Media.FirstOrDefault(st => st.MediaID == Id).Runtime = RunTime;
            }
            if (Description != null)
            {
                _context.Media.FirstOrDefault(st => st.MediaID == Id).Description = Description;
            }
            if (shortDiscription != null)
            {
                _context.Media.FirstOrDefault(st => st.MediaID == Id).ShortDescription = shortDiscription;
            }
            if (Score != null)
            {

                _context.Media.FirstOrDefault(st => st.MediaID == Id).Score = double.Parse(Score.Replace(',','.'), new NumberFormatInfo());
            }
            if (ScoreKP != null)
            {
                _context.Media.FirstOrDefault(st => st.MediaID == Id).ScoreKP = ScoreKP;
            }
            if (Music != null)
            {
                _context.Media.FirstOrDefault(st => st.MediaID == Id).SoundTrackUrl = Music;
            }
            if (Video != null)
            {
                _context.Media.FirstOrDefault(st => st.MediaID == Id).Video = Video;
            }
            if (type != 0)
            {
                _context.Media.FirstOrDefault(st => st.MediaID == Id).MediaType = (MediaType)type;
            }

            IFormFile[] Images = new IFormFile[4] { Images1, Images2, Images3, Images4 };
            if (Images!=null)
            {
                var i = 0;
                foreach(var Img in _context.MediaImages.Where(st=>st.MediaId == Id))
                {
                    if (i < 4)
                    {
                        if(Images[i] != null)
                        Img.MediaImage = SaveImage.getByteImage(Images[i]);
                        i++;
                    }
                }                
            }

            if(genres != null)
            {
                List<Genre> genre = new List<Genre>();

                foreach (var g in _context.Media.Include(st => st.Genres).FirstOrDefault(st => st.MediaID == Id).Genres)
                {
                    var ItemToRemove = g.Medias.FirstOrDefault(st => st.MediaID == Id);
                    if (ItemToRemove != null)
                    {
                        g.Medias.Remove(ItemToRemove);
                    }
                }

                for (var i = 0; i < genres.Length; i++)
                {

                    _context.Media.FirstOrDefault(st => st.MediaID == Id).Genres.Add(_context.Genres.Include(st => st.Medias).FirstOrDefault(st => st.Genre_Name == genres[i]));
                }
            }            

            await _context.SaveChangesAsync();
        }

        [HttpPost]
        public async  Task AddReviews(int idFilm, string Email, string text, double rating)
        {
            var NickName = _context.Users.FirstOrDefault(st => st.Email == Email).Nickname;
            Review review = new Review();            
            review.Description = text;
            review.Rating = rating;
            review.MediaId = idFilm;
            review.UsersId = _context.Users.FirstOrDefault(st => st.Email == Email).UserId;
            review.Nickname = NickName;
            review.DateOfReview = DateTime.Now.ToString();
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReviews(int IdFilm, int IdUser)
        {
            var itemToRemove = await _context.Reviews
                                             .Include(st => st.User)
                                             .Include(st => st.Media)
                                             .SingleOrDefaultAsync(st => st.MediaId == IdFilm && st.UsersId == IdUser);
            if (itemToRemove != null)
            {
                _context.Reviews.Remove(itemToRemove);
            }

            await _context.SaveChangesAsync();
        }

        [HttpPost]
        public async Task EditReviews(int idFilm, int IdUser, string text, double rating)
        {
            if(rating != 0)
            {
                _context.Reviews.FirstOrDefault(st => st.MediaId == idFilm && st.UsersId == IdUser).Rating = rating;
            }
            _context.Reviews.FirstOrDefault(st => st.MediaId == idFilm && st.UsersId == IdUser).Description = text;
            _context.Reviews.FirstOrDefault(st => st.MediaId == idFilm && st.UsersId == IdUser).DateOfReview = DateTime.Now.ToString();
            await _context.SaveChangesAsync();
        }
        public void ChangeRaiting(int IdFilm)
        {
            double score = 0;
            var Reviews = _context.Reviews.Where(st => st.MediaId == IdFilm).ToList();

            foreach (var r in Reviews)
            {
                score += r.Rating;
            }
            if (Reviews.Count > 0)
                score = score / (Reviews.Count);
            else
                score = 0;
            _context.Media.FirstOrDefault(st => st.MediaID == IdFilm).Score = Math.Round(score, 3);
            _context.SaveChanges();
        }

        public async Task<(List<Media>,List<Media>)> GetFilmsForPerson(string Person, int IdPerson, Users User)
        {
            var Films = await GetAllFilms();
            var Serials = await GetAllFilms();

            await Task.WhenAll(GetAllFilms());
            if(User != null && (User.Favorites != null || User.Reviews != null))
            {
                Films = await GetFilms(User);
                Serials = await GetFilms(User);
                await Task.WhenAll(GetAllFilms());
            }

            (List<Media>, List<Media>) Media = (null, null);

            switch (Person)
            {
                case "Actor":
                    Films = Films.Where(st => st.MediaType == MediaType.Film && st.Casts.Where(st => st.Person.Id == IdPerson).FirstOrDefault(st=>st.RoleInFilm == RoleInFilm.Актёр) != null).ToList();
                    Serials = Serials.Where(st => st.MediaType == MediaType.Serial && st.Casts.Where(st => st.Person.Id == IdPerson).FirstOrDefault(st=> st.RoleInFilm == RoleInFilm.Актёр) != null).ToList();
                    break;
                case "Director":
                    Films = Films.Where(st => st.MediaType == MediaType.Film && st.Casts.Where(st => st.Person.Id == IdPerson).FirstOrDefault(st => st.RoleInFilm == RoleInFilm.Режиссёр) != null).ToList();
                    Serials = Serials.Where(st => st.MediaType == MediaType.Serial && st.Casts.Where(st => st.Person.Id == IdPerson).FirstOrDefault(st => st.RoleInFilm == RoleInFilm.Режиссёр) != null).ToList();
                    break;
                case "ScreenWriter":
                    Films = Films.Where(st => st.MediaType == MediaType.Film && st.Casts.Where(st => st.Person.Id == IdPerson).FirstOrDefault(st => st.RoleInFilm == RoleInFilm.Сценарист) != null).ToList();
                    Serials = Serials.Where(st => st.MediaType == MediaType.Serial && st.Casts.Where(st => st.Person.Id == IdPerson).FirstOrDefault(st => st.RoleInFilm == RoleInFilm.Сценарист) != null).ToList();
                    break;
            }
            Media = (Films.ToList(), Serials.ToList());
            return Media;
        }

        public async Task<(List<Media>,List<Media>)> SearchFilmsForActors(string Role1, string Name1,string Role2, string Name2, Users User)
        {
            (List<Media>, List<Media>) Media = (new List<Media>(), new List<Media>());
            (List<Media>, List<Media>) Media1 = (null, null);
            (List<Media>, List<Media>) Media2 = (null, null);
            if (Name1 != null)
            {
                var Person1 = _context.Persons.FirstOrDefault(st => st.Name.ToLower().Contains(Name1.ToLower()));
                if(Person1 == null)
                {
                    return Media;
                }
                Media1 = await GetFilmsForPerson(Role1, Person1.Id, User);
            }
            if(Name2 != null)
            {
                var Person2 = _context.Persons.FirstOrDefault(st => st.Name.ToLower().Contains(Name2.ToLower()));
                if(Person2 == null)
                {
                    return Media;
                }
                Media2 = await GetFilmsForPerson(Role2, Person2.Id, User);
            }
            if (Name1 != null && Name2 != null)
            {
                foreach(var f1 in Media1.Item1)
                {
                    foreach(var f2 in Media2.Item1)
                    {
                        if(f1.MediaID == f2.MediaID)
                        {
                            Media.Item1.Add(f1);
                            break;
                        }
                       }
                }

                foreach (var f1 in Media1.Item2)
                {
                    foreach (var f2 in Media2.Item2)
                    {
                        if (f1.MediaID == f2.MediaID)
                        {
                            Media.Item2.Add(f1);
                            break;
                        }
                    }
                }
            }
            else
            {
                if(Name1 != null)
                {
                    Media = Media1;
                    return Media;
                }
                if(Name2 != null)
                {
                    Media = Media2;
                    return Media;
                }
            }


            return Media;
        }

    }
}
