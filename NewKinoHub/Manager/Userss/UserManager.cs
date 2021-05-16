using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewKinoHub.Storage;
using NewKinoHub.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
                                 .ThenInclude(st => st.Medias)
                                 .Include(st=>st.Viewed)
                                 .ThenInclude(st => st.Medias)
                                 .FirstOrDefaultAsync(st => st.Email == Name);

        }

        public async Task DeleteFavoriteFilms(int idFilm, string Name)
        {
            var itemToRemove = _context.Users
                                       .Include(st => st.Favorites)
                                       .ThenInclude(st => st.Medias)
                                       .FirstOrDefault(st => st.Email == Name)
                                       .Favorites
                                       .Medias
                                       .SingleOrDefault(st => st.MediaID == idFilm);
            if (itemToRemove != null)
            {
                _context.Users
                        .Include(st => st.Favorites)
                        .ThenInclude(st => st.Medias)
                        .FirstOrDefault(st => st.Email == Name)
                        .Favorites
                        .Medias
                        .Remove(itemToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteViewedFilms(int idFilm, string Name)
        {
            var itemToRemove = _context.Users
                                       .Include(st => st.Viewed)
                                       .ThenInclude(st => st.Medias)
                                       .FirstOrDefault(st => st.Email == Name)
                                       .Viewed
                                       .Medias
                                       .SingleOrDefault(st => st.MediaID == idFilm);
            if (itemToRemove != null)
            {
                _context.Users
                        .Include(st => st.Viewed)
                        .ThenInclude(st => st.Medias)
                        .FirstOrDefault(st => st.Email == Name)
                        .Viewed
                        .Medias
                        .Remove(itemToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddFavoriteFilms(int id, string Name)
        {

            if (_context.Users.Include(st => st.Favorites).ThenInclude(st => st.Medias).FirstOrDefault(st => st.Email == Name).Favorites == null)
            {
                Favorites f = new Favorites();
                f.Medias.Add(_context.Media.FirstOrDefault(st => st.MediaID == id));
                f.UserName = Name;

                _context.Users
                        .FirstOrDefault(st => st.Email == Name)
                        .Favorites = f;
                              
                              

            }
            else
            {
                 _context.Users
                         .FirstOrDefault(st => st.Email == Name)
                         .Favorites
                         .Medias
                         .Add(_context.Media.FirstOrDefault(st => st.MediaID == id));
            }
            await _context.SaveChangesAsync();
        }

        public async Task AddViewedFilms(int id, string Name)
        {

            if (_context.Users.Include(st => st.Viewed).ThenInclude(st => st.Medias).FirstOrDefault(st => st.Email == Name).Viewed == null)
            {
                Viewed V = new Viewed();
                V.Medias.Add(_context.Media.FirstOrDefault(st => st.MediaID == id));
                V.UserName = Name;

                _context.Users
                        .FirstOrDefault(st => st.Email == Name)
                        .Viewed = V;
            }
            else
            {
                _context.Users
                        .FirstOrDefault(st => st.Email == Name)
                        .Viewed
                        .Medias
                        .Add(_context.Media.FirstOrDefault(st => st.MediaID == id));
            }
            await _context.SaveChangesAsync();
        }

        [HttpPost]
        public async Task EditAccount(IFormFile mainPhoto, string name, string DataB,string Email)
        {

            if(mainPhoto != null)
            {
                _context.Users.FirstOrDefault(st => st.Email == Email).Image = SaveImage.getByteImage(mainPhoto);
            }
            if(DataB != null)
            {
                _context.Users.FirstOrDefault(st => st.Email == Email).DateOfBirthday = DataB;
            }
            if (name != null)
            {
                _context.Users.FirstOrDefault(st => st.Email == Email).Nickname = name;
            }
            await _context.SaveChangesAsync();
        }

        public int GetRights(Users User)
        {
            if (User != null)
                return (int)User.Role;
            else
                return 0;
        }

        public byte [] GetImage(string Email)
        {
            return _context.Users.FirstOrDefault(st => st.Email == Email).Image;
        }

        public string GetNameUser(string Email)
        {
            return _context.Users.FirstOrDefault(st => st.Email == Email).Nickname;
        }

        public bool ImageNull(string Email)
        {
            return _context.Users.FirstOrDefault(st => st.Email == Email).Image == null ? true : false;
        }

        public int GetUserId(string Email)
        {
            return _context.Users.FirstOrDefault(st => st.Email == Email).UserId;
        }
    }
}
