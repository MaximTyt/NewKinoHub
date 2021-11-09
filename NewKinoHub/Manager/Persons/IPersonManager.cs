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
        Task<Person> GetPersonForId(int IdPerson);
        Task DeletePerson(int IdPerson);
        Task AgeOfPerson(int personId);
        Task AgeOfPerson();
        Task EditPerson(int personId, string Name, string OriginalName,
           bool IsActor, bool IsScreenWriter, bool IsDirector, double Height, string Image, DateTime DateOfBirthday, DateTime DateOfDeath, string PlaceOfBirthday,
           string PlaceOfDeath, string Spouse, string Awards, string Description);
    }
}
