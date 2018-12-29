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
    public class ProductController : Controller
    {
        // GET: Product
        [HttpGet]
        public ActionResult urunEkle()
        {
            if (Session["kullaniciAdi"] == null) return View();
            else return View("Index");
        }

        [HttpPost]
        public ActionResult urunEkle(Product product)
        {
            IProductService productService = Business.IocUtil.Resolve<IProductService>();
            string userName = Session["kullaniciAdi"].ToString();
            product.PublishDate = DateTime.Now;
            IMapService mapService = IocUtil.Resolve<IMapService>();
            mapService.FillAddress(product);
            bool added = productService.Add(userName, product);

            if (added) return View("About", "Home");
            else return View();
        }
    }
}