using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce.Models.DataModel;
using E_Commerce.Models.Helper;
using E_Commerce.CF;

namespace E_Commerce.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        Context _db = Connection.Connect();

        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Login()
        {
            if ((string)Session["AdiSoyadi"] !=null&&(string)Session["AdiSoyadi"] !="")
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection frm)
        {
            try
            {
                string ViewUserMail = frm.Get("email");
                string ViewUserPassword = frm.Get("password");
                BaseUser ToLogin = _db.Users.FirstOrDefault(x => x.EMail == ViewUserMail && x.Password == ViewUserPassword);
                if (ToLogin != null)
                {
                    Session.Add("AdiSoyadi", (ToLogin.Name + " " + ToLogin.Surname));
                    Session.Add("UserID", ToLogin.BaseUserID);
                    Session.Add("Authority", ToLogin.Authority);
                }
            }
            catch (Exception e)
            {

                ViewBag.Mesaj = e.Message;
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
        public ActionResult LogOut()
        {
            Session.Remove("AdiSoyadi");
            Session.Remove("UserID");
            Session.Remove("Authority");
            return RedirectToAction("Index", "Home");
        }
    }
}