using NewKinoHub.Storage.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KinoHab.Manager
{
    public interface IFilmManager
    {
        Task<ICollection<Media>> GetAllFilms();
        Task<Media> GetFilmforId(int filmId,Users User);
        RoleInFilm Cast(int i);
        MediaType TypeFilm(string i);
        Task<ICollection<Media>> AllSorting(string sort, Users User);
        Task<ICollection<Media>> Filtration(int filtr, Users User);
        string GetNameFiltr(int idFiltr);
        Task<ICollection<Media>> SortingFromFiltr(string sort, ICollection<Media> media);
        Task<ICollection<Media>> GetFilms(Users User);
        Task<ICollection<Media>> GetFavoritFilmsForUser(Users User);
        Task<Users> GetUser(string UserEmail);

    }
}
