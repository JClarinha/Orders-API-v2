using OrdersAPI.Domain;

namespace OrdersAPI.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer GetById(int id);
        List<Customer> GetByName(string name);
        Customer Add(Customer customer);
        Customer Update(Customer customer);
        void Remove(Customer customer);
    }
}
