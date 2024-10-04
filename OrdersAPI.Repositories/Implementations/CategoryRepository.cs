using OrdersAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data;
using OrdersAPI.Data.Context;
using OrdersAPI.Repositories.Interfaces;

namespace OrdersAPI.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbSet<Category> _dbSet;

        public CategoryRepository(OrdersApiDBContext ordersApiDBContext)
        {
            _dbSet = ordersApiDBContext.Set<Category>();
        }

        public List<Category> GetAll()
        {
            return _dbSet.ToList(); // SELECT * FROM Categorys;
        }

        public Category GetById(int id)
        {
            return _dbSet.FirstOrDefault(category => category.Id == id); // SELECT * FROM Categorys WHERE Id = id;
        }

        public bool GetAny(int id)
        {
            return _dbSet.Any(category => category.Id == id);
        }

        public List<Category> GetByName(string name)
        {
            return _dbSet.Where(category => category.Name.Contains(name)).ToList(); // SELECT * FROM Categorys WHERE Name LIKE '%name%';
        }

        public Category Add(Category category)
        {
            _dbSet.Add(category); // INSERT INTO Categorys (Colmuns) VALUES (values);

            return category;
        }

        public Category Update(Category category)
        {
            _dbSet.Update(category); // UPDATE Categorys SET Column = value, ... WHERE Id = id;

            return category;
        }

        public void Remove(Category category)
        {
            _dbSet.Remove(category); // DELETE FROM Categorys WHERE Id = Category.Id
        }

    }
}
