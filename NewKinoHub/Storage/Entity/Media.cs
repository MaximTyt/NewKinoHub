using NewKinoHub.Storage.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewKinoHub.Storage.Entity
{
    public class Media
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MediaID { get; set; }
        [Required]
        [Range(0,1)]
        public MediaType MediaType { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]        
        public string Img { get; set; }

        [Required]        
        public string Video { get; set; }

        [Required]
        public string SoundTrackUrl { get; set; }

        [Required]        
        public int Year { get; set; }        

        [Required]        
        public string Country { get; set; }

        [Required]        
        public int Age { get; set; }

        [Required]
        public string ScoreKP { get; set; }        

        [Required]
        [Range(1.0,10.0)]
        public double Score { get; set; }

        [DataType(DataType.Date)]        
        public string Release_Date { get; set; }

        [Required]        
        public string Runtime { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]        
        public string ShortDescription { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]        
        public string Description { get; set; }

        public int? NumOfSeason { get; set; }
        public int? NumOfEpisodes { get; set; }

        public List<Genre> Genres { get; set; } = new List<Genre>();
        public List<MediaImages> Images { get; set; } = new List<MediaImages>();        
        public List<Cast> Casts { get; set; } = new List<Cast>();
        public bool IsVieweds { get; set; }
        public bool IsFavorites { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();


    }
    public enum MediaType
    {
        Film,
        Serial
    }
}
