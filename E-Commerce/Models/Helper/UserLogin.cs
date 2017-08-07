using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Commerce.Models.Helper
{
    public class UserLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}