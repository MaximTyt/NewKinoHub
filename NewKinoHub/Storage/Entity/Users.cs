using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewKinoHub.Storage.Entity
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        [Range(0, 2)]
        public Role Role { get; set; }
        public int? FavoritesId { get; set; }
        public Favorites Favorites { get; set; }
        public int? ViewedId { get; set; }
        public Viewed Viewed { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
    public enum Role
    {
        Admin,
        User
    }
}
