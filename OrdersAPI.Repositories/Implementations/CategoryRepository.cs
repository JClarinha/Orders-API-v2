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
        private readonly OrdersApiDBContext _ordersApiDBContext;

        public CategoryRepository(OrdersApiDBContext ordersApiDBContext)
        {
            _dbSet = ordersApiDBContext.Set<Category>();
            _ordersApiDBContext = ordersApiDBContext;


        }


        public List<Category> GetAll()
        {
            return _dbSet.ToList(); // SELECT * FROM Category;
        }

        public Category GetById(int id)
        {
            return _dbSet.FirstOrDefault(p => p.Id == id); // SELECT * FROM Category WHERE Id = ao imput 

        }


        public List<Category> GetByName(string name)
        {
            return _dbSet.Where(p => p.Name.Contains(name)).ToList(); // SELECT * FROM Category WHERE Name LIKE '%name%'
        }

        public Category Add(Category category)
        {
            _dbSet.Add(category); // INSERT INTO Category (Collums) Values (Values)
            _ordersApiDBContext.SaveChanges();
            return category;

        }


        public Category Update(Category category)
        {
            _dbSet.Update(category); // UPDATE Category SET Collum = VALUE, ... , WHERE Id=Id
            _ordersApiDBContext.SaveChanges();
            return category;

        }

        public void Remove(Category category)
        {
            _dbSet.Remove(category); // DELET FROM Category WHEERE Id = category.Id
            _ordersApiDBContext.SaveChanges();


        }




    }
}
