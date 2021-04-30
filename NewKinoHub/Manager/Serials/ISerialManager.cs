using NewKinoHub.Storage.Entity;
using System.Collections.Generic;

namespace KinoHab.Manager
{
    public interface ISerialManager
    {
     ICollection<Media> GetAllSerials();
     Media GetSerialforId(int filmId);

    //ICollection<TVshow> Sorting(string sort);
    }
}
