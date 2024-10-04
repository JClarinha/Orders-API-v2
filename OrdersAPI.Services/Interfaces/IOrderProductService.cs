using OrdersAPI.Domain;

namespace OrdersAPI.Services.Interfaces
{
    public interface IOrderProductService
    {
        List<OrderProduct> GetAll();
        List<OrderProduct> GetAllByOrderId(int orderId);
        OrderProduct SaveOrderProduct(OrderProduct orderProduct);
        void RemoveOrderProduct(int id);
    }
}

