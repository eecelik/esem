using Business;
using Business.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ProductsController : ApiController
    {
        // GET api/products
        public IHttpActionResult Get()
        {
            IProductService productService = IocUtil.Resolve<IProductService>();

            return Ok(productService.GetList());
        }

        // GET api/products?categoryId=
        public IHttpActionResult Get(int categoryId)
        {
            IProductService productService = IocUtil.Resolve<IProductService>();

            return Ok(productService.GetList().Where(x=> x.CategoryId == categoryId));
        }
    }
}
