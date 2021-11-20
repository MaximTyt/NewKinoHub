using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace NewKinoHub.Storage.Entity
{
    public class RegisterModel
    {        
        public string Nickname { get; set; }
        [Required(ErrorMessage = "Не указан электронный адрес")]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        [Remote(action: "VerifyEmail", controller: "Users")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Не введён пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Подтвердите пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirm { get; set; }
        public string Salt { get; set; }
        public Random Code { get; set; }
    }
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан email")]
        [Remote(action: "VerifyEmail", controller: "Users")]
        public string Email { get; set; }        
                
        [Required(ErrorMessage = "Не введён пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    public class HashSalt
    {
        public string Hash { get; set; }
        public string Salt { get; set; }
        public static HashSalt GenerateSaltedHash(int size, string password)
        {
            var saltBytes = new byte[size];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(saltBytes);
            var salt = Convert.ToBase64String(saltBytes);

            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            var hashPassword = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            HashSalt hashSalt = new HashSalt { Hash = hashPassword, Salt = salt };
            return hashSalt;
        }
    }  
}
