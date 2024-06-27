

using Entities;

namespace Business
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category getById(int categoryId);
    }
}
