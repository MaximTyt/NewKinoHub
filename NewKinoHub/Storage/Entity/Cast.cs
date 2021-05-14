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
        public int? MediaId { get; set; }
        public Media Media { get; set; }
        public int? PersonId { get; set; }
        public Person Person { get; set; }
        public RoleInFilm RoleInFilm { get; set; }
        public string Character { get; set; }
    }
    public enum RoleInFilm
    {
        Режиссёр,
        Сценарист,
        Актёр
    }
}
