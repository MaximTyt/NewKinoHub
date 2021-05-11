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
        Task AddFavoriteFilms(int id, string Name);
        Task DeleteFavoriteFilms(int idFilms, string Name);
        Task EditAccount(string mainPhoto, string name, string DataB, string Login);
        int GetRights(Users User);
        Task AddViewedFilms(int id, string Name);
        Task DeleteViewedFilms(int idFilm, string Name);
    }
}
