using OrdersAPI.Data.Context;
using OrdersAPI.Domain;
using OrdersAPI.Repositories.Interfaces;
using OrdersAPI.Services.Interfaces;

namespace OrdersAPI.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private OrdersApiDBContext _ordersApiDBContext;
        private IOrderRepository _orderRepository;

        public OrderService(OrdersApiDBContext ordersApiDBContext, IOrderRepository orderRepository)
        {
            _ordersApiDBContext = ordersApiDBContext;
            _orderRepository = orderRepository;
        }

        public List<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public Order GetById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public Order SaveOrder(Order order)
        {
            
            bool orderExists = _orderRepository.GetAny(order.Id);

            if (!orderExists)
            {
                // FT-2024/1
                var orderNumLast = _orderRepository.GetLast().OrderNum;
                var orderDateLast = _orderRepository.GetLast().OrderDate;

                if (orderDateLast.Year != DateTime.Now.Year)
                {
                    order.OrderNum = "FT-" + DateTime.Now.Year + "/1";
                }
                else
                {
                    var lastNum = Convert.ToInt32(orderNumLast.Substring(orderNumLast.IndexOf('/') + 1));

                    lastNum++;

                    order.OrderNum = "FT-" + DateTime.Now.Year + "/" + lastNum;
                }

                order.OrderDate = DateTime.Now;
               

                order = _orderRepository.Add(order);
            }
            else
            {
                order = _orderRepository.Update(order);
            }

            _ordersApiDBContext.SaveChanges();
            

            return order;
        }

        public void RemoveOrder(int id)
        {
            Order orderResult = _orderRepository.GetById(id);

            if (orderResult != null)
            {
                _orderRepository.Remove(orderResult);

                _ordersApiDBContext.SaveChanges();
            }
        }
    }






}
