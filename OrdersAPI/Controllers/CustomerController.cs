using Microsoft.AspNetCore.Mvc;
using OrdersAPI.Domain;
using OrdersAPI.Services.Implemntations;
using OrdersAPI.Services.Interfaces;

namespace OrdersAPI.Controllers
{
    [Route("OrdersAPI/[Controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{id}")]

        public Customer GetById(int id) {
            return _customerService.GetById(id);
        }
        /*public bool Login(int id)
        {
            Customer customerResult = _customerService.GetById(id);

            if (customerResult == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }*/

        [HttpGet]
        public List<Customer> GetAllCustomers()
        {
            return _customerService.GetAll();
        }

        [HttpPost]
        public Customer SaveCustomer(Customer customer)
        {
            return _customerService.SaveCustomer(customer);
        }

        [HttpDelete("{id}")]
        public void DeleteCustomer(int id)
        {
            _customerService.RemoveCustomer(id);
        }
    }
}
