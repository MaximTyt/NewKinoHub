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
        public string RolesInMedia { get; set; }
        [Range(0.49,2.5)]
        public double Height { get; set; }
        public string Image { get; set; }        
        public DateTime DateOfBirthday { get; set; }
        public int Age { get; set; }
        public DateTime DateOfDeath { get; set; } 
        public string PlaceOfBirthday { get; set; }
        public string PlaceOfDeath { get; set; }
        public string Spouse { get; set; }

        public string Awards { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public List<Cast> Casts { get; set; } = new List<Cast>(); 
    }
}
