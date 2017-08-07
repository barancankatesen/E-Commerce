using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using E_Commerce.Models.DataModel;

namespace E_Commerce.CF
{
    public class Context:DbContext
    {
        public Context()
        {
            Database.Connection.ConnectionString = "server=.;database=DbCommerce;user id=sa;password=123456789?";
        }

        public DbSet<BaseUser> Users { get; set; }


    }
}