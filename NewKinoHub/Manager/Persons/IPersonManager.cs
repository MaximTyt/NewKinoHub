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
    }
}
