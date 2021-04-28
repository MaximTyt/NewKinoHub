using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewKinoHub.Storage.Entity
{
    public class Model
    {
        public class RegisterModel
        {
            [Required(ErrorMessage = "Не указан логин")]
            [Remote(action: "VerifyLogin", controller: "Users")]
            public string Login { get; set; }
            [Required(ErrorMessage = "Не указан электронный адрес")]
            [EmailAddress(ErrorMessage = "Некорректный адрес")]
            [Remote(action: "VerifyEmail", controller: "Users")]
            public string Email { get; set; }
            [Required(ErrorMessage = "Не введён пароль")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
            [Required(ErrorMessage = "Подтвердите пароль")]
            [Compare("Password", ErrorMessage = "Пароли не совпадают")]
            public string PasswordConfirm { get; set; }
        }
    }
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан логин")]
        [Remote(action: "VerifyLogin", controller: "Users")]
        public string Login { get; set; }        
                
        [Required(ErrorMessage = "Не введён пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
