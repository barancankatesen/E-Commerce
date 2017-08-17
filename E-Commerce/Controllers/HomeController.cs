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
            if ((string)Session["AdiSoyadi"] != null && (string)Session["AdiSoyadi"] != "")
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

        public ActionResult SignUp()
        {
            UserSignUp ToSignUp = new UserSignUp();
            return View(ToSignUp);
        }
        [HttpPost]
        public ActionResult SignUp(FormCollection frm)
        {
            UserSignUp ToConfirm = new UserSignUp();
            ToConfirm.TermAndConditions = Convert.ToBoolean(frm.Get("TermAndConditions"));

            string ViewPassword = frm.Get("Password");
            string ViewPasswordAgain = frm.Get("PasswordAgain");

            string ViewName = frm.Get("Name");
            string ViewSurname = frm.Get("Surname");
            string ViewMail = frm.Get("EMail");
            BaseUser ToAdd = new BaseUser();
            ToAdd.Authority = "UnConfirmed";
            ToAdd.EMail = ViewMail;
            ToAdd.Name = ViewName;
            ToAdd.Password = ViewPassword;
            ToAdd.Surname = ViewSurname;
            ToConfirm.Name = ViewName;
            ToConfirm.Surname = ViewSurname;
            ToConfirm.EMail = ViewMail;
            
            
            if (ViewPassword != ViewPasswordAgain)
           
            {
                ViewBag.Mesaj = "Şifreleriniz Uyuşmuyor";
                return View(ToConfirm);
            }

            if (!ToConfirm.TermAndConditions)
            {
                ViewBag.Mesaj = "Sisteme Kayıt Olabilmeniz İçin Kullanıcı Sözleşmesini Onaylamanız Gerekir";
                return View(ToConfirm);
            }
            _db.Users.Add(ToAdd);
            if (_db.SaveChanges() > 0)
            {
                return RedirectToAction("SuccessPage", "Home");
            }
            else
            {
                ViewBag.Mesaj = "Veritabanı Bağlantısı Sırasında Bir Hata Oluştu";
            }
            return View(ToConfirm);
        }

        public ActionResult SuccessPage()
        {
            return View();
        }
        public ActionResult TermandConditions()
        {

            return View();
        }
        public ActionResult Help()
        {
            return View();
        }
    }
}