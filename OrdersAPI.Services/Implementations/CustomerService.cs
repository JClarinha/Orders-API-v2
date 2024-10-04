using OrdersAPI.Data.Context;
using OrdersAPI.Domain;
using OrdersAPI.Repositories.Implementations;
using OrdersAPI.Repositories.Interfaces;
using OrdersAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersAPI.Services.Implemntations
{
    public class CustomerService : ICustomerService
    {
        private OrdersApiDBContext _ordersApiDBContext;
        private ICustomerRepository _customerRepository;

        public CustomerService(OrdersApiDBContext ordersApiDBContext, ICustomerRepository customerRepository)
        {
            _ordersApiDBContext = ordersApiDBContext;
            _customerRepository = customerRepository;
        }

        public List<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public Customer SaveCustomer(Customer customer)
        {

            bool customerExists = _customerRepository.GetAny(customer.Id);

            if (!customerExists)
            {
                customer = _customerRepository.Add(customer);
            }
            else
            {
                customer = _customerRepository.Update(customer);
            }

            _ordersApiDBContext.SaveChanges();

            return customer;


            /*Customer customerResult = _customerRepository.GetById(customer.Id);

            if (customerResult == null)
            {
                customer = _customerRepository.Add(customer);
            }
            else
            {
                customer = _customerRepository.Update(customer);
            }

            _ordersApiDBContext.SaveChanges();

            return customer;*/
        }

        public void RemoveCustomer(int id)
        {
            Customer customerResult = _customerRepository.GetById(id);

            if (customerResult != null)
            {
                _customerRepository.Remove(customerResult);

                _ordersApiDBContext.SaveChanges();
            }
        }
    }
}
