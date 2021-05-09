using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewKinoHub.Storage;
using NewKinoHub.Storage.Entity;
using System;
using System.Collections.Generic;
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
                        .Favorites.Medias
                        .Remove(itemToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddFilms(int id, string Name)
        {

            if (_context.Users.Include(st => st.Favorites).ThenInclude(st => st.Medias).FirstOrDefault(st => st.Email == Name).Favorites == null)
            {
                Favorites f = new Favorites();
                f.Medias.Add(_context.Media.FirstOrDefault(st => st.MediaID == id));
                f.UserName = Name;

                //_context.Users.Include(st => st.Favorites)
                //        .ThenInclude(st => st.Medias)
                //        .FirstOrDefault(st => st.Login == Name)
                //        .Favorites = f;

                _context.Users

                        .FirstOrDefault(st => st.Email == Name)

                        .Favorites = f;
                              
                              

            }
            else
            {
                //_context.Users.Include(st => st.Favorites)
                //              .ThenInclude(st => st.Medias)
                //              .FirstOrDefault(st => st.Login == Name)
                //              .Favorites
                //              .Medias
                //              .Add(_context.Media.FirstOrDefault(st => st.MediaID == id));

                 _context.Users

                         .FirstOrDefault(st => st.Email == Name)
                         .Favorites.Medias
                         .Add(_context.Media.FirstOrDefault(st => st.MediaID == id));
            }
            await _context.SaveChangesAsync();
        }
        [HttpPost]
        public async Task EditAccount(string mainPhoto, string name, string DataB,string Email)
        {

            if(mainPhoto != null)
            {
                _context.Users.FirstOrDefault(st => st.Email == Email).Image = mainPhoto;
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


        //public static byte[] getByteImage(IFormFile file)
        //{
        //    byte[] fileData = null;

        //    using (var binaryReader = new BinaryReader(file.OpenReadStream()))
        //    {
        //        fileData = binaryReader.ReadBytes((int)file.Length);
        //    }

        //    return fileData;
        //}

    }
}
