using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce.Models.DataModel;
using E_Commerce.CF;
using E_Commerce.Models.Helper;

namespace E_Commerce.Controllers
{
    public class AdminController : Controller
    {
        Context _db = Connection.Connect();
        public bool AuthorityCheck()
        {
            if ((string)Session["Authority"] != "Admin" && (string)Session["Authority"] != "Master")
            {
                return true;
            }
            return false;
        }
        // GET: Admin
        public ActionResult Index()
        {
            if (AuthorityCheck())
            {
                return RedirectToAction("Index", "Home");

            }
            return View();

        }

        public ActionResult Settings()
        {
            if (AuthorityCheck())
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult ChangeNameSurname()
        {
            if (AuthorityCheck())
            {
                return RedirectToAction("Index", "Home");
            }

            UserNameSurname ToEdit = new UserNameSurname();
            ToEdit.ID =Convert.ToInt32(Session["UserID"]);
            

            var ToEditFromDb  =_db.Users.Where(x => x.BaseUserID == Convert.ToInt32(Session["UserID"])).Select(x => new  {x.Name, x.Surname }).FirstOrDefault();
            ToEdit.Name = ToEditFromDb.Name;
            ToEdit.Surname = ToEditFromDb.Surname;
           
            return View(ToEdit);
        }


    }
}