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
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }

        public bool Add(Category category)
        {
            if (string.IsNullOrEmpty(category.CategoryName)) return false;

            categoryDal.Add(category);
            return true;
        }

        public void Delete(int categoryId)
        {
            categoryDal.Delete(categoryDal.Get(x => x.Id == categoryId));
        }

        public Category Get(int categoryId)
        {
            return categoryDal.Get(x => x.Id == categoryId);
        }

        public List<Category> GetList()
        {
            return categoryDal.GetList();
        }
    }
}
