using NewKinoHub.Storage.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KinoHab.Manager
{
    public interface IFilmManager
    {
        Task<ICollection<Media>> GetAllFilms();
        Task<Media> GetFilmforId(int filmId);
        RoleInFilm Cast(int i);
        Task<ICollection<Media>> GetAllSerials();
        Task<Media> GetSerialforId(int filmId);
        Task<ICollection<Media>> AllSorting(string sort,string type);
        Task<ICollection<Media>> Filtration(int filtr, string type);
        string GetNameFiltr(int idFiltr);
        Task<ICollection<Media>> SortingFromFiltr(string sort, ICollection<Media> media);

    }
}
