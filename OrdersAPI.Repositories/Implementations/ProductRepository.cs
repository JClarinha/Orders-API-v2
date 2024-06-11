using Microsoft.EntityFrameworkCore;
using OrdersAPI.Data.Context;
using OrdersAPI.Domain;
using OrdersAPI.Repositories.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace OrdersAPI.Repositories.Implementations
{
    public class ProductRepository :IProductRepository
    {
        private readonly DbSet<Product> _dbSet;
        private readonly OrdersApiDBContext _ProductApiDBContext;

        public ProductRepository(OrdersApiDBContext ProductApiDBContext)
        {
            _dbSet = ProductApiDBContext.Set<Product>();
            _ProductApiDBContext = ProductApiDBContext;


        }


        public List<Product> GetAll()
        {
            return _dbSet.ToList(); // SELECT * FROM Product;
        }

        public Product GetById(int id)
        {
            return _dbSet.FirstOrDefault(p => p.Id == id); // SELECT * FROM Product WHERE Id = ao imput 

        }


        public Product Add(Product Product)
        {
            _dbSet.Add(Product); // INSERT INTO Product (Collums) Values (Values)
            _ProductApiDBContext.SaveChanges();
            return Product;

        }


        public Product Update(Product Product)
        {
            _dbSet.Update(Product); // UPDATE Product SET Collum = VALUE, ... , WHERE Id=Id
            _ProductApiDBContext.SaveChanges();
            return Product;

        }

        public void Remove(Product Product)
        {
            _dbSet.Remove(Product); // DELET FROM Product WHEERE Id = Product.Id
            _ProductApiDBContext.SaveChanges();


        }
    }
}
