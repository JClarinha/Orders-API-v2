using OrdersAPI.Domain;

namespace OrdersAPI.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category GetById(int id);
        bool GetAny(int id);
        List<Category> GetByName(string name);
        Category Add(Category category);
        Category Update(Category category);
        void Remove(Category category);
    }
}
