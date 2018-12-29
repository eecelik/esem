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
            if (Session["kullaniciAdi"] == null) return Redirect("/User/Login");
            else
            {
                ICategoryService serviceCategori = IocUtil.Resolve<ICategoryService>();
                ViewData["Categories"]=serviceCategori.GetList();
                return View();
            }
        }
        [HttpGet]
        public ActionResult Index(int id)
        {
            Product gIlan = IocUtil.Resolve<IProductService>().Get(id);
            return View(gIlan);
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

            if (added) return Redirect("User/Index");
            else return View();
        }
    }
}