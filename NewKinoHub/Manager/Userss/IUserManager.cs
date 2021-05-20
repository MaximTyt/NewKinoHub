using Microsoft.AspNetCore.Http;
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
        Task EditAccount(IFormFile mainPhoto, string name, DateTime DataB, string Login);
        int GetRights(Users User);
        Task AddViewedFilms(int id, string Name);
        Task DeleteViewedFilms(int idFilm, string Name);
        byte[] GetImage(string Email);
        bool ImageNull(string Email);
        bool FavoritesNull(string Email);
        int GetUserId(string Email);

    }
}
