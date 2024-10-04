using Microsoft.EntityFrameworkCore;
using OrdersAPI.Data.Context;
using OrdersAPI.Domain;
using OrdersAPI.Repositories.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace OrdersAPI.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
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
            return _dbSet.Include(p => p.Customer).ToList(); ;
        }

        public Order GetById(int id)
        {
            return _dbSet.FirstOrDefault(order => order.Id == id);
        }

        public bool GetAny(int id)
        {
            return _dbSet.Any(order => order.Id == id);
        }

        public Order GetLast()
        {
            return _dbSet.OrderByDescending(p => p.OrderDate).FirstOrDefault();
        }

        public List<Order> GetByName(string orderNum)
        {
            return _dbSet.Where(order => order.OrderNum.Contains(orderNum)).ToList();
        }

        public Order Add(Order order)
        {
            _dbSet.Add(order);

            _ordersApiDBContext.SaveChanges();

            return order;
        }

        public Order Update(Order order)
        {
            _dbSet.Update(order);

            _ordersApiDBContext.SaveChanges();

            return order;
        }

        public void Remove(Order order)
        {
            _dbSet.Remove(order);

            _ordersApiDBContext.SaveChanges();
        }

    }
}
