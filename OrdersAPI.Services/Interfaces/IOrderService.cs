using OrdersAPI.Domain;

namespace OrdersAPI.Services.Interfaces
{
    public interface IOrderService
    {
        List<Order> GetAll();
        Order GetById(int id);
        Order SaveOrder(Order order);
        void RemoveOrder(int id);
    }
}
