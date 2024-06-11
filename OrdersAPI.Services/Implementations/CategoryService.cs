using OrdersAPI.Data.Context;
using OrdersAPI.Domain;
using OrdersAPI.Repositories.Interfaces;
using OrdersAPI.Services.Interfaces;

namespace OrdersAPI.Services.Implemntations
{
    public class CategoryService : ICategoryService

    {

        private OrdersApiDBContext _ordersApiDBContext;
        private ICategoryRepository _categoryRepopsitory;
        public CategoryService(OrdersApiDBContext orderApiDbContext,ICategoryRepository categoryRepopsitory)
        {
            _ordersApiDBContext = orderApiDbContext;
            _categoryRepopsitory = categoryRepopsitory;
        }

        public List<Category> GetAll()
        {
            return _categoryRepopsitory.GetAll();    
        }


        public Category SaveCategory(Category category)
        {
            Category categoryResult = _categoryRepopsitory.GetById(category.Id);

            if (categoryResult == null)
            {
                _categoryRepopsitory.Add(category);
            }

            else
            {
                category = _categoryRepopsitory.Update(category);
            }

            return category;
        }

        public void RemoveCategory(int id)
        {
            Category categoryResult = _categoryRepopsitory.GetById(id);

            if (categoryResult != null)
            {
                _categoryRepopsitory.Remove(categoryResult);

                _ordersApiDBContext.SaveChanges();
            }
          
        }
    }
}
