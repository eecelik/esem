using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            if (User.Identity.IsAuthenticated) return RedirectToAction("Index");
            else return View("Login");
        }

        // POST: User/Login
        [HttpPost]
        public ActionResult Login(Account loginUser)
        {
            ILoginService loginService = Business.IocUtil.Resolve<ILoginService>();
            bool login = loginService.Login(loginUser.Username, loginUser.Password);

            if (login)
            {
                FormsAuthentication.SetAuthCookie(loginUser.Username, false, "/");
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

        public ActionResult Anasayfa()
        {
            return View();
        }
    }
}
