using Microsoft.EntityFrameworkCore;
using OrdersAPI.Data.Context;
using OrdersAPI.Domain;
using OrdersAPI.Repositories.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace OrdersAPI.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbSet<Product> _dbSet;
        private readonly OrdersApiDBContext _ordersApiDBContext;

        public ProductRepository(OrdersApiDBContext ordersApiDBContext)
        {
            _dbSet = ordersApiDBContext.Set<Product>();
            _ordersApiDBContext = ordersApiDBContext;
        }

        public List<Product> GetAll()
        {
            return _dbSet.Include(p => p.Category).ToList();
        }

        public Product GetById(int id)
        {
            return _dbSet.FirstOrDefault(product => product.Id == id);
        }

        public bool GetAny(int id)
        {
            return _dbSet.Any(product => product.Id == id);
        }

        public Product Add(Product product)
        {
            _dbSet.Add(product);

            _ordersApiDBContext.SaveChanges();

            return product;
        }

        public Product Update(Product product)
        {
            _dbSet.Update(product);

            _ordersApiDBContext.SaveChanges();

            return product;
        }

        public void Remove(Product product)
        {
            _dbSet.Remove(product);

            _ordersApiDBContext.SaveChanges();
        }

    }
}
