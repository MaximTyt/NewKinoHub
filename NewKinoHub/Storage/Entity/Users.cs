using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace NewKinoHub.Storage.Entity
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage = "Не введён пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Salt { get; set; }
        public byte[] Image { get; set; }
        [Range(0, 1)]
        public Role Role { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public int? FavoritesId { get; set; }
        public Favorites Favorites { get; set; }
        public int? ViewedId { get; set; }
        public Viewed Viewed { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
        public bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            var saltBytes = Convert.FromBase64String(storedSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(enteredPassword, saltBytes, 10000);
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == storedHash;
        }
    }
    public enum Role
    {
        Admin=1,
        User=0
    }
}
