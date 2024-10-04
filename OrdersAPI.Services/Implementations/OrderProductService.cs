using OrdersAPI.Data.Context;
using OrdersAPI.Domain;
using OrdersAPI.Repositories.Interfaces;
using OrdersAPI.Services.Interfaces;

namespace OrdersAPI.Services.Implementations
{
    public class OrderProductService : IOrderProductService
    {
        private OrdersApiDBContext _ordersApiDBContext;
        private IOrderProductRepository _orderProductRepository;

        public OrderProductService(OrdersApiDBContext ordersApiDBContext, IOrderProductRepository orderProductRepository)
        {
            _ordersApiDBContext = ordersApiDBContext;
            _orderProductRepository = orderProductRepository;
        }

        public List<OrderProduct> GetAll()
        {
            return _orderProductRepository.GetAll();
        }

        public List<OrderProduct> GetAllByOrderId(int orderId)
        {
            return _orderProductRepository.GetAllByOrderId(orderId);
        }

        public OrderProduct SaveOrderProduct(OrderProduct orderProduct)
        {
            OrderProduct orderProductResult = _orderProductRepository.GetById(orderProduct.Id);

            orderProduct.Product = null;
            orderProduct.Order = null;

            if (orderProductResult == null)
            {
                orderProduct = _orderProductRepository.Add(orderProduct);
            }
            else
            {
                orderProduct = _orderProductRepository.Update(orderProduct);
            }

            _ordersApiDBContext.SaveChanges();

            return orderProduct;
        }

        public void RemoveOrderProduct(int id)
        {
            OrderProduct orderProductResult = _orderProductRepository.GetById(id);

            if (orderProductResult != null)
            {
                _orderProductRepository.Remove(orderProductResult);

                _ordersApiDBContext.SaveChanges();
            }
        }
    }
}
