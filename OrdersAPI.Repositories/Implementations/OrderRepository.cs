using Microsoft.EntityFrameworkCore;
using OrdersAPI.Data.Context;
using OrdersAPI.Domain;
using OrdersAPI.Repositories.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace OrdersAPI.Repositories.Implementations
{
    public class OrderRepository :IOrderRepository
    {
        private readonly DbSet<Order> _dbSet;
        private readonly OrdersApiDBContext _ordersApiDBContext;

        public OrderRepository(OrdersApiDBContext ordersApiDBContext)
        {
            _dbSet = ordersApiDBContext.Set<Order>();
            _ordersApiDBContext = ordersApiDBContext;


        }


        public List<Order> GetAll()
        {
            return _dbSet.ToList(); // SELECT * FROM Order;
        }

        public Order GetById(int id)
        {
            return _dbSet.FirstOrDefault(p => p.Id == id); // SELECT * FROM Order WHERE Id = ao imput 

        }


        public Order Add(Order Order)
        {
            _dbSet.Add(Order); // INSERT INTO Order (Collums) Values (Values)
            _ordersApiDBContext.SaveChanges();
            return Order;

        }


        public Order Update(Order Order)
        {
            _dbSet.Update(Order); // UPDATE Order SET Collum = VALUE, ... , WHERE Id=Id
            _ordersApiDBContext.SaveChanges();
            return Order;

        }

        public void Remove(Order Order)
        {
            _dbSet.Remove(Order); // DELET FROM Order WHEERE Id = Order.Id
            _ordersApiDBContext.SaveChanges();


        }
    }
}
