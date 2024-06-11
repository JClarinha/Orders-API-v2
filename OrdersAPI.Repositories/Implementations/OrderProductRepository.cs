using Microsoft.EntityFrameworkCore;
using OrdersAPI.Data.Context;
using OrdersAPI.Domain;
using OrdersAPI.Repositories.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace OrdersAPI.Repositories.Implementations
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly DbSet<OrderProduct> _dbSet;
        private readonly OrdersApiDBContext _ordersApiDBContext;

        public OrderProductRepository(OrdersApiDBContext ordersApiDBContext)
        {
            _dbSet = ordersApiDBContext.Set<OrderProduct>();
            _ordersApiDBContext = ordersApiDBContext;


        }


        public List<OrderProduct> GetAll()
        {
            return _dbSet.ToList(); // SELECT * FROM OrderProduct;
        }

        public OrderProduct GetById(int id)
        {
            return _dbSet.FirstOrDefault(p => p.Id == id); // SELECT * FROM OrderProduct WHERE Id = ao imput 

        }




        public OrderProduct Add(OrderProduct OrderProduct)
        {
            _dbSet.Add(OrderProduct); // INSERT INTO OrderProduct (Collums) Values (Values)
            _ordersApiDBContext.SaveChanges();
            return OrderProduct;

        }


        public OrderProduct Update(OrderProduct OrderProduct)
        {
            _dbSet.Update(OrderProduct); // UPDATE OrderProduct SET Collum = VALUE, ... , WHERE Id=Id
            _ordersApiDBContext.SaveChanges();
            return OrderProduct;

        }

        public void Remove(OrderProduct OrderProduct)
        {
            _dbSet.Remove(OrderProduct); // DELET FROM OrderProduct WHEERE Id = OrderProduct.Id
            _ordersApiDBContext.SaveChanges();


        }
    }
}
