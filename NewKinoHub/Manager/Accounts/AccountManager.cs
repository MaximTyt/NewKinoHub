using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewKinoHub.Manager.Accounts;
using NewKinoHub.Storage;
using NewKinoHub.Storage.Entity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
namespace NewKinoHub.Manager
{
    public class AccountManager : IAccountManager
    {
        private MvcFilmContext db;
        public AccountManager(MvcFilmContext context)
        {
            db = context;
        }

        public async Task AddUsers(RegisterModel model)
        {
            db.Users.Add(new Users { Nickname = model.Nickname, Email = model.Email, Password = model.Password });
            await db.SaveChangesAsync();
        }

        public async Task<Users> GetUser(LoginModel model)
        {
            Users user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
            return user;
        }

        public async Task<Users> GetUser1(RegisterModel model)
        {
            Users user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            return user;
        }
    }
}
