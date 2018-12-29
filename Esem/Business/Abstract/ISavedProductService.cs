using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISavedProductService
    {
        void Save(int accountId, int productId);
        List<SaveProduct> GetList();
    }
}
