
using DataAccess;
using Entities;

namespace Business
{
    public class CategoryManager:ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category getById(int categoryId)
        {
            return _categoryDal.Get(c=>c.CategoryId == categoryId);
        }
    }
}
