using OrdersAPI.Domain;

namespace OrdersAPI.Repositories.Interfaces
{
    public interface IOrderProductRepository
    {
        List<OrderProduct> GetAll();
        List<OrderProduct> GetAllByOrderId(int orderId);
        OrderProduct GetById(int id);
        OrderProduct Add(OrderProduct orderProduct);
        OrderProduct Update(OrderProduct orderProduct);
        void Remove(OrderProduct orderProduct);
    }
}
