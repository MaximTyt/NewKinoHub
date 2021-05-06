using NewKinoHub.Storage;
using NewKinoHub.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewKinoHub.Manager.Userss
{
    public interface IUserManager
    {
        Task<Users> GetUsers(string Name);
        Task AddFilms(int id, string Name);

        Task DeleteFilms(int idFilms, string Name);
    }
}
