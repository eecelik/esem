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
            ILoginService a = Business.IocUtil.Resolve<ILoginService>();
            Account nAccount = new Account();
            nAccount.Firstname = loginUser.Firstname;
            nAccount.Lastname = loginUser.Lastname;
            nAccount.Mail = loginUser.Mail;
            nAccount.Password = loginUser.Password;
            nAccount.Username = loginUser.Username;
            if (a.Register(nAccount))
            {
                return View("Login");
            }
            return RedirectToAction("Index");

        }
        // GET: User/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        // POST: User/Login
        [HttpPost]
        public ActionResult Login(Account loginUser)
        {
            ILoginService a = Business.IocUtil.Resolve<ILoginService>();
            bool login = a.Login(loginUser.Username, loginUser.Password);
            if (login)
            {
                FormsAuthentication.SetAuthCookie(loginUser.Username,false);
                return View("Register");
            }
            return View();
        }



        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
