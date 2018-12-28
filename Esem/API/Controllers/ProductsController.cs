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
        public IEnumerable<Product> Get()
        {
            IProductService productService = IocUtil.Resolve<IProductService>();

            return productService.GetList();
        }
    }
}
