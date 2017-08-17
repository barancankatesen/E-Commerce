using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Commerce.Models.Helper
{
    public class UserLogin
    {
        [EmailAddress(ErrorMessage = "Hatalı Mail Adresi!!!"),
             Required(ErrorMessage = "Lütfen Mail Adresi Giriniz")]
        public string Email { get; set; }
        [StringLength(maximumLength: 1000, ErrorMessage = "Şifre 3 karakterden az olamaz", MinimumLength = 3),
         DataType(DataType.Password),
         Display(Name = "Eski Şifrenizi giriniz"),
            Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")
            ]
        public string Password { get; set; }
    }
}