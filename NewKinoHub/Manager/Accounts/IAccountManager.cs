using NewKinoHub.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewKinoHub.Manager.Accounts
{
    public interface IAccountManager
    {
        public Task SendEmail(string email, string nickname);        
        public Task<Users> GetUser(LoginModel model);

        public Task<Users> GetUser1(RegisterModel model);

        public Task AddUsers(RegisterModel model);

    }
}
