using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Business.Abstract;
using Entities;

namespace UI.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            Session["kullaniciAdi"] = null;
            return View();
        }

        // GET: User/Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // POST: User/Register
        [HttpPost]
        public ActionResult Register(Account loginUser)
        {
            ILoginService loginService = Business.IocUtil.Resolve<ILoginService>();

            if (loginService.Register(loginUser)) return View("Login");
            else return RedirectToAction("Index");
        }

        // GET: User/Login
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["kullaniciAdi"] == null ) return View();
            else return View("Index");
        }

        // POST: User/Login
        [HttpPost]
        public ActionResult Login(Account loginUser)
        {
            ILoginService loginService = Business.IocUtil.Resolve<ILoginService>();
            bool login = loginService.Login(loginUser.Username, loginUser.Password);

            if (login)
            {
                FormsAuthentication.SetAuthCookie(loginUser.Username, true);
                Session["kullaniciAdi"] = loginUser.Username;
                return View("Index");
            }
            else return View();
        }

        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}
