using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewKinoHub.Storage.Entity
{
    public class Favorites
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<Users> Users { get; set; } = new List<Users>();
        public List<Media> Medias { get; set; } = new List<Media>();
    }
}
