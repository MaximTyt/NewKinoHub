using NewKinoHub.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewKinoHub.Manager.Home
{
    public interface IHomeManager
    {
        (List<Media>,List<Media>) GetNewPopularFilms();
        Task<(List<Media>, List<Media>)> Search(string Name, Users User);
        RoleInFilm Cast(int i);
    }
}
