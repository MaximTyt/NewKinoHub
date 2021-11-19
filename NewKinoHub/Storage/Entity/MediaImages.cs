using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewKinoHub.Storage.Entity
{
    public class MediaImages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImagesID { get; set; }
        public int MediaId { get; set; }
        [Required]
        public byte[] MediaImage { get; set; }
        public Media Medias { get; set; }
    }
}
