using OrdersAPI.Data.Context;
using OrdersAPI.Domain;
using OrdersAPI.Repositories.Interfaces;
using OrdersAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersAPI.Services.Implementations
{
    public class OrderService : IOrderService

    {

        private OrdersApiDBContext _ordersApiDBContext;
        private IOrderRepository _orderRepopsitory;
        public OrderService(OrdersApiDBContext orderApiDbContext, IOrderRepository OrderRepopsitory)
        {
            _ordersApiDBContext = orderApiDbContext;
            _orderRepopsitory = OrderRepopsitory;
        }

        public List<Order> GetAll()
        {
            return _orderRepopsitory.GetAll();
        }


        public Order SaveOrder(Order Order)
        {
            Order OrderResult = _orderRepopsitory.GetById(Order.Id);

            if (OrderResult == null)
            {
                _orderRepopsitory.Add(Order);
            }

            else
            {
                Order = _orderRepopsitory.Update(Order);
            }

            return Order;
        }

        public void RemoveOrder(int id)
        {
            Order OrderResult = _orderRepopsitory.GetById(id);

            if (OrderResult != null)
            {
                _orderRepopsitory.Remove(OrderResult);

                _ordersApiDBContext.SaveChanges();
            }

        }
    }
}
