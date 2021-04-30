using Microsoft.EntityFrameworkCore;
using NewKinoHub.Storage;
using NewKinoHub.Storage.Entity;
using System.Collections.Generic;
using System.Linq;

namespace KinoHab.Manager.Serials
{
    public class SerialManager : ISerialManager
    {
        private MvcFilmContext _context;
        public SerialManager(MvcFilmContext context)
        {
            _context = context;
        }
        public ICollection<Media> GetAllSerials()
        {
            return _context.Media.Where(st=>st.MediaType == MediaType.Serial).Include(st => st.Genres).ToList();
        }

        public Media GetSerialforId(int serialId)
        {
            var serial = _context.Media.Include(st => st.Genres).FirstOrDefault(st => st.MediaID == serialId);
            return serial;
        }

      //lic ICollection<TVshow> Sorting(string sort)
      //
      // var serial = _context.TVshows.ToList();
      // if (sort == "YearOld")
      // {
      //     serial = _context.TVshows.OrderBy(st => st.Year).ToList();
      // }
      // if (sort == "YearNew")
      // {
      //     serial = _context.TVshows.OrderByDescending(st => st.Year).ToList();
      // }
      // if (sort == "Score")
      // {
      //     serial = _context.TVshows.OrderByDescending(st => st.Score).ToList();
      // }
      // if (sort == "NameA")
      // {
      //     serial = _context.TVshows.OrderBy(st => st.Name).ToList();
      // }
      // if (sort == "NameZ")
      // {
      //     serial = _context.TVshows.OrderByDescending(st => st.Name).ToList();
      // }
      // return serial;
      // }
    }
}
