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
    public class SavedProductManager : ISavedProductService
    {
        private ISaveProductDal saveProductDal;
        private IProductDal productDal;

        public SavedProductManager(ISaveProductDal saveProductDal, IProductDal productDal)
        {
            this.saveProductDal = saveProductDal;
            this.productDal = productDal;
        }

        public List<SaveProduct> GetList()
        {
            return saveProductDal.GetList();
        }

        public void Save(int accountId, int productId)
        {
            if (accountId == 0 || productId == 0) return;

            SaveProduct saveProduct = new SaveProduct { AccountId = accountId, ProductId = productId };
            saveProductDal.Add(saveProduct);
        }
    }
}
