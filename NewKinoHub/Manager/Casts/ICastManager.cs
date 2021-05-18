using NewKinoHub.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewKinoHub.Manager.Casts
{
    public interface ICastManager
    {
        Task<Cast> GetPersonforId(int personId);
        Task<ICollection<Cast>> GetAllCast(int castId);
        RoleInFilm Cast(int i);
        Task AgeOfPerson(int personId);
    }
}
