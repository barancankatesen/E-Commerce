using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.CF
{
    public class Connection
    {
        private static Context _db = null;
        public static Context Connect()
        {
            if (_db == null)
            {
                _db = new Context();
            }

            return _db;


        }
    }
}