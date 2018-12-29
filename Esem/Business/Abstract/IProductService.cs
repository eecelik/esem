using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        bool Add(string username, Product product);
        Product Get(int productId);
        List<Product> GetList();
        void Delete(int productId);
    }
}
