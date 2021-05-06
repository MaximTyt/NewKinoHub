using Microsoft.EntityFrameworkCore;
using NewKinoHub.Storage;
using NewKinoHub.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewKinoHub.Manager.Userss
{
    public class UserManager : IUserManager
    {
        private readonly MvcFilmContext _context;
        public UserManager(MvcFilmContext context)
        {
            _context = context;
        }
        public async Task<Users> GetUsers(string Name)
        {
            return await _context.Users
                                 .Include(st => st.Favorites)
                                 .ThenInclude(st=>st.Medias)
                                 .FirstOrDefaultAsync(st=>st.Login == Name);
        }

        public async Task DeleteFilms(int idFilm, string Name)
        {
            var itemToRemove = _context.Users
                                       .Include(st => st.Favorites)
                                       .ThenInclude(st => st.Medias)
                                       .FirstOrDefault(st => st.Login == Name)
                                       .Favorites
                                       .Medias
                                       .SingleOrDefault(st => st.MediaID == idFilm);
            if (itemToRemove != null)
            {
                _context.Users
                        .Include(st => st.Favorites)
                        .ThenInclude(st => st.Medias)
                        .FirstOrDefault(st => st.Login == Name)
                        .Favorites.Medias
                        .Remove(itemToRemove);
                _context.SaveChanges();
            }
        }

        public async Task AddFilms(int id,string Name)
        {

            if (_context.Users.Include(st => st.Favorites).ThenInclude(st => st.Medias).FirstOrDefault(st => st.Login == Name).Favorites == null)
            {
                Favorites f = new Favorites();
                f.Medias.Add(_context.Media.FirstOrDefault(st=>st.MediaID == id));
                f.UserName = Name;
                _context.Users.Include(st => st.Favorites)
                              .ThenInclude(st => st.Medias)
                              .FirstOrDefault(st => st.Login == Name)
                              .Favorites = f;
            }
            else
            {
                _context.Users.Include(st => st.Favorites)
                              .ThenInclude(st => st.Medias)
                              .FirstOrDefault(st => st.Login == Name)
                              .Favorites
                              .Medias
                              .Add(_context.Media.FirstOrDefault(st => st.MediaID == id));
            }
            _context.SaveChanges();
        }
    }
}
