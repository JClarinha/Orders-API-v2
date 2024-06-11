using OrdersAPI.Domain;

namespace OrdersAPI.Repositories.Interfaces
{
    public interface IOrderProductRepository
    {
        List<OrderProduct> GetAll();
        OrderProduct GetById(int id);
        OrderProduct Add(OrderProduct OrderProduct);
        OrderProduct Update(OrderProduct OrderProduct);
        void Remove(OrderProduct OrderProduct);
    }
}
