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
using System.Net.Mail;
using System.Net;
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

            if (Name != null)
            {
                var User = await _context.Users.FirstOrDefaultAsync(st => st.Email == Name);
                var Favorites = await _context.Favorites.Include(st => st.Medias).FirstOrDefaultAsync(st => st.UserName == Name);
                User.Favorites = Favorites;
                var Vieweds = await _context.Vieweds.Include(st => st.Medias).FirstOrDefaultAsync(st => st.UserName == Name);
                User.Viewed = Vieweds;
                return User;
            }
            else
            {
                return null;
            }
        }

        public async Task<Users> GetUser(string Email)
        {
            Users user = await _context.Users.FirstOrDefaultAsync(u => u.Email == Email);
            return user;
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
        public async Task EditAccount(IFormFile mainPhoto, string name, DateTime DataB,string Email)
        {

            if(mainPhoto != null)
            {
                _context.Users.FirstOrDefault(st => st.Email == Email).Image = SaveImage.getByteImage(mainPhoto);
            }
            if (DataB.Year != 0001)
            {
                _context.Users.FirstOrDefault(st => st.Email == Email).DateOfBirthday = DataB;
            }
            if (name != null)
            {
                _context.Users.FirstOrDefault(st => st.Email == Email).Nickname = name;
            }
            await _context.SaveChangesAsync();
        }
        public async Task<Random> SendEmailForChangePassword(string email)
        {
            SmtpClient SmtpClient = new();
            // set smtp-client with basicAuthentication
            SmtpClient.Host = "smtp.gmail.com";
            SmtpClient.Port = 587;
            SmtpClient.EnableSsl = true;
            SmtpClient.UseDefaultCredentials = false;
            SmtpClient.Credentials = new NetworkCredential("kinohubloveyou@gmail.com", "55j-vuM-DUR-kXi");
            // add from,to mailaddresses
            MailAddress from = new("kinohubloveyou@gmail.com", "Поддержка KinoHub");
            MailAddress to = new("imaximtyt@gmail.com", "Тебе, ёбанный сыр");
            MailMessage myMail = new(from, to);
            // add ReplyTo
            MailAddress replyTo = new("kinohubloveyou@gmail.com");
            myMail.ReplyToList.Add(replyTo);

            // set subject and encoding
            myMail.Subject = "Код подтверждения";
            myMail.SubjectEncoding = System.Text.Encoding.UTF8;

            // set body-message and encoding
            Random code = new();
            myMail.Body = $"<b>Код подтверждения:</b>{code.Next(100000, 999999)}<b></b>.";
            myMail.BodyEncoding = System.Text.Encoding.UTF8;
            // text or html
            myMail.IsBodyHtml = true;
            await SmtpClient.SendMailAsync(myMail);
            return code;
        }
        public async Task SendEmailAboutChangePassword(string email)
        {
            SmtpClient SmtpClient = new();
            // set smtp-client with basicAuthentication
            SmtpClient.Host = "smtp.gmail.com";
            SmtpClient.Port = 587;
            SmtpClient.EnableSsl = true;
            SmtpClient.UseDefaultCredentials = false;
            SmtpClient.Credentials = new NetworkCredential("kinohubloveyou@gmail.com", "55j-vuM-DUR-kXi");
            // add from,to mailaddresses
            MailAddress from = new("kinohubloveyou@gmail.com", "Поддержка KinoHub");
            MailAddress to = new(email, "Тебе, ёбанный сыр");
            MailMessage myMail = new(from, to);
            // add ReplyTo
            MailAddress replyTo = new("kinohubloveyou@gmail.com");
            myMail.ReplyToList.Add(replyTo);

            // set subject and encoding
            myMail.Subject = "Смена пароля";
            myMail.SubjectEncoding = System.Text.Encoding.UTF8;

            // set body-message and encoding            
            myMail.Body = "<b>Ваш пароль был изменен!</b><b></b>.";
            myMail.BodyEncoding = System.Text.Encoding.UTF8;
            // text or html
            myMail.IsBodyHtml = true;
            await SmtpClient.SendMailAsync(myMail);
        }
        public async Task EditPassword(string newPassword, string newSalt, string Email)
        {
            if (newPassword != null)
            {
                _context.Users.FirstOrDefault(st => st.Email == Email).Password = newPassword;
                await SendEmailAboutChangePassword(Email);
            }
            if (newSalt != null)
            {
                _context.Users.FirstOrDefault(st => st.Email == Email).Salt = newSalt;
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
            if(Email != null)
                 return _context.Users.FirstOrDefault(st => st.Email == Email).UserId;
            return 0;
        }
        public bool FavoritesNull(string Email)
        {
            return _context.Users.Include(st=>st.Favorites).FirstOrDefault(st => st.Email == Email).Favorites == null ? true : false;
        }
    }
}
