using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models.Helper
{
    public class UserPassword
    {
        public int UserID { get; set; }

        [StringLength(maximumLength: 1000, ErrorMessage = "Şifre 3 karakterden az olamaz", MinimumLength = 3),
         DataType(DataType.Password),
         Display(Name = "Eski Şifrenizi giriniz"),
            Required(ErrorMessage = "Lütfen Eski Şifrenizi Giriniz")
            ]
        public string OldPassword { get; set; }
        [StringLength(maximumLength: 1000, ErrorMessage = "Şifre 3 karakterden az olamaz", MinimumLength = 3),
         DataType(DataType.Password),
         Display(Name = "Yeni Şifrenizi giriniz"),
            Required(ErrorMessage = "Lütfen Yeni Şifrenizi Giriniz")
            ]
        public string NewPassword { get; set; }
        [StringLength(maximumLength: 1000, ErrorMessage = "Şifre 3 karakterden az olamaz", MinimumLength = 3),
         DataType(DataType.Password),
         Display(Name = "Yeni Şifrenizi Tekrar giriniz"),
            Required(ErrorMessage = "Lütfen Yeni Şifrenizi Tekrar Giriniz")
            ]
        public string NewPasswordAgain { get; set; }
    }
}