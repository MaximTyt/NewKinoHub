using Microsoft.EntityFrameworkCore;
using NewKinoHub.Manager.Accounts;
using NewKinoHub.Storage;
using NewKinoHub.Storage.Entity;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Security.Cryptography;

namespace NewKinoHub.Manager
{
    public class AccountManager : IAccountManager
    {
        private MvcFilmContext db;
        public AccountManager(MvcFilmContext context)
        {
            db = context;
        }

        public async Task SendEmail(string email, string nickname)
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
            myMail.Subject = "WelCOME";
            myMail.SubjectEncoding = System.Text.Encoding.UTF8;

            // set body-message and encoding            
            myMail.Body = $"<b>WelCOME to the club, {nickname}!</b>";
            myMail.BodyEncoding = System.Text.Encoding.UTF8;
            // text or html
            myMail.IsBodyHtml = true;
            await SmtpClient.SendMailAsync(myMail);            
        }
               

        public async Task AddUsers(RegisterModel model)
        {
            
            db.Users.Add(new Users { Nickname = model.Nickname, Email = model.Email, Password = model.Password,Salt=model.Salt });
            await db.SaveChangesAsync();
        }

        public async Task<Users> GetUser(LoginModel model)
        {            
            Users user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            return user;
        }

        public async Task<Users> GetUser1(RegisterModel model)
        {
            Users user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            return user;
        }
    }
}
