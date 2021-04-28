using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewKinoHub.Storage.Entity
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string OriginalName { get; set; }
        public string Height { get; set; }
        [Required]
        public string DateOfBirthday { get; set; }
        public string DateOfDeath { get; set; }        
        
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        List<(RoleInFilm?, RoleInFilm?, RoleInFilm?)> Roles =  new List<(RoleInFilm?, RoleInFilm?, RoleInFilm?)>();
        public List<Cast> Casts { get; set; } = new List<Cast>();        
    }
}
