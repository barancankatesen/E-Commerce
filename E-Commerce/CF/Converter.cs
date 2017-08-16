using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_Commerce.Models.Helper;

namespace E_Commerce.CF
{
    public class Converter
    {
        public static UserNameSurname ToUserNameSurname(dynamic ToConvert)
        {
            UserNameSurname ToSend = new UserNameSurname();
            ToSend.ID = ToConvert.BaseUserID;
            ToSend.Name = ToConvert.Name;
            ToSend.Surname = ToConvert.Surname;
            return ToSend;
        }
    }
}