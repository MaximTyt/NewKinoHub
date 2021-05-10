using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewKinoHub.Storage.Entity
{
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenreId { get; set; }
        [Required]
        public string Genre_Name { get; set; }
        public int NumOfGenre { get; set; }

        public List<Media> Medias { get; set; } = new List<Media>(); 
    }
}
