using NewKinoHub.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewKinoHub.Manager.Casts
{
    public interface ICastManager
    {
        Task<Person> GetPersonforId(int personId);
        Task<ICollection<Cast>> GetAllActors(int FilmId);
        Task<ICollection<Cast>> GetAllCast(int FilmId);
        RoleInFilm Cast(int i);        
        Task AddCast(int IdFilm, string Character, int RoleInFilm, string Name, string OriginalName,
            string RolesInMedia, double Height, string Image, DateTime DateOfBirthday, DateTime DateOfDeath, string PlaceOfBirthday,
            string PlaceOfDeath, string Spouse, string Awards, string Description);
        Task DeleteCast(int IdCast);
        List<Person> Search(string Name);
        Task AddSearchPerson(int IdFilm, int IdPerson,int role);
        Task EditCast(int IdCast, int IdFilm, string Character, int RoleInFilm);
        Task<Cast> GetCastForId(int IdCast, int IdFilm);
    }
}
