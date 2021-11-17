using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewKinoHub.Storage.Entity
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { get; set; }
        public string DateOfReview { get; set; }

        [DataType(DataType.MultilineText)]        
        public string Description { get; set; }
        public string Nickname { get; set; }
        public byte[] ImgUser { get; set; }
        public int MediaId { get; set; }
        public double Rating { get; set; }
        public Media Media { get; set; }

        public int UsersId { get; set; }
        public Users User { get; set; }

    }
}
