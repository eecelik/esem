using Business;
using Business.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        [HttpGet]
        public ActionResult urunEkle()
        {
            if (Session["kullaniciAdi"] == null) return View("Login","User");
            else return View();
        }

        [HttpPost]
        public ActionResult urunEkle(Product product, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var path = Path.Combine(Server.MapPath("~/img"), file.FileName);
                file.SaveAs(path);
                TempData["result"] = "Güncelleme Başarılı.";
            }

            IProductService productService = Business.IocUtil.Resolve<IProductService>();
            string userName = Session["kullaniciAdi"].ToString();
            product.PublishDate = DateTime.Now;
            product.ImagePath= Path.Combine(Server.MapPath("~/img"), file.FileName);
            IMapService mapService = IocUtil.Resolve<IMapService>();
            mapService.FillAddress(product);
            bool added = productService.Add(userName, product);

            if (added) return View("About", "Home");
            else return View();
        }
    }
}