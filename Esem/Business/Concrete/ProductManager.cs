using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal productDal;

        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }

        public void Add(Product product)
        {
            //kontrol ettiricez
            productDal.Add(product);
        }

        public void Delete(int productId)
        {
            productDal.Delete(productDal.Get(x => x.Id == productId));
        }

        public Product Get(int productId)
        {
            return productDal.Get(x => x.Id == productId);
        }

        public List<Product> GetList()
        {
            return productDal.GetList();
        }
    }
}
