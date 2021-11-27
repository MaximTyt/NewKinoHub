using Microsoft.AspNetCore.Http;
using NewKinoHub.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewKinoHub.Manager.Persons
{
    public interface IPersonManager
    {  
        Task<ICollection<Person>> GetPersons();
        Task<ICollection<Person>> GetPersons(int role);
        Task<Person> GetPersonForId(int IdPerson);
        Task DeletePerson(int IdPerson);
        Task AgeOfPerson(int personId);
        Task AgeOfPerson();
        Task EditPerson(int personId, string Name, string OriginalName,
           bool IsActor, bool IsScreenWriter, bool IsDirector, double Height, IFormFile mainPhoto, DateTime DateOfBirthday, DateTime DateOfDeath, string PlaceOfBirthday,
           string PlaceOfDeath, string Spouse, string Awards, string Description);
        Task<ICollection<Person>> AllSorting(string sort);
        Task<List<Person>> Filtration(string Actors, string Directors, string ScreenWriter);
        List<Person> SortingFromFiltr(string sort, List<Person> Filtr);
        string GetPersonName(int IdPerson);
        Task AddPerson(string Name, string OriginalName,
            string IsActor, string IsScreenWriter, string IsDirector, double Height, IFormFile mainPhoto, DateTime DateOfBirthday, DateTime DateOfDeath, string PlaceOfBirthday,
            string PlaceOfDeath, string Spouse, string Awards, string Description);
    }
}
