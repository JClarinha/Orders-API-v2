using OrdersAPI.Domain;

namespace OrdersAPI.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        Order GetById(int id);
        Order Add(Order Order);
        Order Update(Order Order);
        void Remove(Order Order);
    }
}
