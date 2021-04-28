using System.Collections.Generic;

namespace NewKinoHub.Storage.Entity
{
    public class Viewed
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<Users> Users { get; set; } = new List<Users>();
        public List<Media> Medias { get; set; } = new List<Media>();
    }
}
