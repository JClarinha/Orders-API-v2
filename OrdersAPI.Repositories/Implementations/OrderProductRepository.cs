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
            return _dbSet.ToList();
        }

        public List<OrderProduct> GetAllByOrderId(int orderId)
        {
            return _dbSet.Where(p => p.OrderId == orderId).Include(p => p.Product).ToList();
        }

        public OrderProduct GetById(int id)
        {
            return _dbSet
                .Where(p => p.Id == id)
                .Include(p => p.Order)
                .ThenInclude(p => p.Customer)
                .Include(p => p.Product)
                .ThenInclude(p => p.Category)
                .FirstOrDefault();
        }

        public OrderProduct Add(OrderProduct orderProduct)
        {
            _dbSet.Add(orderProduct);

            _ordersApiDBContext.SaveChanges();

            return orderProduct;
        }

        public OrderProduct Update(OrderProduct orderProduct)
        {
            _dbSet.Update(orderProduct);

            _ordersApiDBContext.SaveChanges();

            return orderProduct;
        }

        public void Remove(OrderProduct order)
        {
            _dbSet.Remove(order);

            _ordersApiDBContext.SaveChanges();
        }

    }
}
