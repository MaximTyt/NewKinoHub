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
        public Media()
        {
            Score = 0;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MediaID { get; set; }
        [Required]
        [Range(0,1)]
        public MediaType MediaType { get; set; }

        [Required]
        public string Name { get; set; }

        public byte[] Img { get; set; }
                       
        public string Video { get; set; }
                
        public string SoundTrackUrl { get; set; }
               
        public string Country { get; set; }

        [Required]        
        public int Age { get; set; }
                
        public string ScoreKP { get; set; }

        [Required]
        [Range(1.0, 10.0)]
        public double Score { get; set; }
                    
        public DateTime Release_Date { get; set; }
                        
        public string Runtime { get; set; }

        [DataType(DataType.MultilineText)]                
        public string ShortDescription { get; set; }

        [DataType(DataType.MultilineText)]                
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
