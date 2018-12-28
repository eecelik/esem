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
        public ActionResult Index(Product product)
        {
            IProductService productService = Business.IocUtil.Resolve<IProductService>();
            string userName = Session["kullaniciAdi"].ToString();
            productService.Add(userName,product);
            return View("Index");
        }
    }
}