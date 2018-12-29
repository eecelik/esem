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
        private IAccountDal accountDal;

        public ProductManager(IProductDal productDal, IAccountDal accountDal)
        {
            this.productDal = productDal;
            this.accountDal = accountDal;
        }

        public bool Add(string username, Product product)
        {
            Account account = accountDal.Get(x => x.Username == username);

            if (product.CategoryId == 0 || product.Price == null || string.IsNullOrEmpty(product.Name) || product.Image == null || product.LongLat == null || product.PublishDate == null)
                return false;

            product.AccountId = account.Id;
            productDal.Add(product);
            return true;
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
