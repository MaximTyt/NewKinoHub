using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewKinoHub.Storage.Entity
{
    public class Cast
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MediaId { get; set; }
        public List<Person> Persons { get; set; } = new List<Person>();
        public Media Media { get; set; }
        [Range(0,2)]
        public RoleInFilm RoleInFilm { get; set; }
        public string Character { get; set; }

    }
    public enum RoleInFilm
    {
        Director,
        Screenwriter,
        Actor
    }
}
