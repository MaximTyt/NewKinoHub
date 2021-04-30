using NewKinoHub.Storage.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KinoHab.Manager
{
    public interface IFilmManager
    {
        Task<ICollection<Media>> GetAllFilms();
        Task<Media> GetFilmforId(int filmId);
     // ICollection<Media> AllSorting(string sort);
     //
     // ICollection<Media> SortingForFiltr(string sort, ICollection<Media> films);
     //
     // ICollection<Media> Filtration(int filtr);
    }
}
