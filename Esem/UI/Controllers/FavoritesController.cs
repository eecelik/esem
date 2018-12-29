using Business;
using Business.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class FavoritesController : Controller
    {
        // GET: Favorites
        [HttpGet]
        public ActionResult Index()
        {
            ISavedProductService savedProductService = IocUtil.Resolve<ISavedProductService>();

            ViewData["favorites"] = savedProductService.GetList();

            return View();
        }

        [HttpPost]
        public ActionResult AddFavorite(int productId)
        {
            ISavedProductService savedProductService = IocUtil.Resolve<ISavedProductService>();
            IAccountService accountService = IocUtil.Resolve<IAccountService>();

            Account account = accountService.Get(Session["kullaniciAdi"].ToString());

            savedProductService.Save(account.Id, productId);

            //ürün fava kaydedildi.
            return View();
        }
    }
}