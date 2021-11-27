using NewKinoHub.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewKinoHub.Manager.Home
{
    public interface IHomeManager
    {
        (List<Media>,List<Media>,List<Media>) GetNewPopularFilms(string Email);
        Task<(List<Media>, List<Media>, List<Person>)> Search(string Name, Users User);
        Task<ICollection<Person>> AdvancedSearch(Users User);
        List<Media> Recommendation(Users User);
    }
}
