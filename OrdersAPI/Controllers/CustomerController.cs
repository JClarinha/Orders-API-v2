using Microsoft.AspNetCore.Mvc;
using OrdersAPI.Domain;
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
        [HttpGet]
        public List<Customer> GetCustomer()
        {
            return _customerService.GetAll();
        }

        [HttpPost]   
        public Customer SaveCustomer(Customer customer) 
        {
            return _customerService.SaveCustomer(customer);   
        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            _customerService.RemoveCustomer(id);
        }
    }
}
