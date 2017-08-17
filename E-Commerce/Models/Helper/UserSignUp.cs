using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Web;


namespace E_Commerce.Models.Helper
{
    public class UserSignUp
    {
        [Required(ErrorMessage = "Lütfen İsim Giriniz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen Soyisim Giriniz")]
        public string Surname { get; set; }
        [EmailAddress(ErrorMessage = "hatalı mail adresi!!!"),
            Required(ErrorMessage = "Lütfen Mail Adresi Giriniz")]
        public string EMail { get; set; }
        [StringLength(maximumLength: 1000, ErrorMessage = "Şifre 3 karakterden az olamaz", MinimumLength = 3),
        DataType(DataType.Password),
        Required(ErrorMessage = "Lütfen Şifre Giriniz")
           ]
        public string Password { get; set; }
        [StringLength(maximumLength: 1000, ErrorMessage = "Şifre 3 karakterden az olamaz", MinimumLength = 3),
        DataType(DataType.Password),
        Required(ErrorMessage = "Lütfen Şifre Giriniz")
           ]
        public string PasswordAgain { get; set; }
        [Required(ErrorMessage ="Lütfen Kullanımı Koşullarını Kabul ediniz")]
        public bool TermAndConditions { get; set; }
    }
}