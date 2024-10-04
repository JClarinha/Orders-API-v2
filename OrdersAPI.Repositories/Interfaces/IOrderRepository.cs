using OrdersAPI.Domain;

namespace OrdersAPI.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        Order GetById(int id);
        bool GetAny(int id);
        Order GetLast();
        List<Order> GetByName(string name);
        Order Add(Order order);
        Order Update(Order order);
        void Remove(Order order);
    }
}
