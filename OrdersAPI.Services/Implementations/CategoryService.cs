using OrdersAPI.Data.Context;
using OrdersAPI.Domain;
using OrdersAPI.Repositories.Implementations;
using OrdersAPI.Repositories.Interfaces;
using OrdersAPI.Services.Interfaces;

namespace OrdersAPI.Services.Implemntations
{
    public class CategoryService : ICategoryService
    {
        private OrdersApiDBContext _ordersApiDBContext;
        private ICategoryRepository _categoryRepository;

        public CategoryService(OrdersApiDBContext ordersApiDBContext, ICategoryRepository categoryRepository)
        {
            _ordersApiDBContext = ordersApiDBContext;
            _categoryRepository = categoryRepository;
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public Category SaveCategory(Category category)
        {
            bool categoryExists = _categoryRepository.GetAny(category.Id);

            if (!categoryExists)
            {
                category = _categoryRepository.Add(category);
            }
            else
            {
                category = _categoryRepository.Update(category);
            }

            _ordersApiDBContext.SaveChanges();

            return category;
        }

        /*public Category SaveCategory(Category category)
        {
           Category categoryResult = _categoryRepository.GetById(category.Id);

            if (categoryResult == null)
            {
                category = _categoryRepository.Add(category);
            }
            else
            {
                categoryResult.Name = category.Name;
                category = _categoryRepository.Update(categoryResult);
            }

            _ordersApiDBContext.SaveChanges();

            return category;
        }*/


        public void RemoveCategory(int id)
        {
            Category categoryResult = _categoryRepository.GetById(id);

            if (categoryResult != null)
            {
                _categoryRepository.Remove(categoryResult);

                _ordersApiDBContext.SaveChanges();
            }
        }
    }
}
