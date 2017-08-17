using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Commerce.Models.Helper
{
    public class UserNameSurname
    {
        [Required(ErrorMessage = "Lütfen İsim Giriniz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen Soyisim Giriniz")]
        public string Surname { get; set; }
    }
}