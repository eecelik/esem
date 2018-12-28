using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        bool Add(Category category);
        Category Get(int categoryId);
        List<Category> GetList();
        void Delete(int categoryId);
    }
}
