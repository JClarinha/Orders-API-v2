using OrdersAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersAPI.Services.Interfaces
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        Customer SaveCustomer(Customer customer);
        void RemoveCustomer(int id);
    }
}
