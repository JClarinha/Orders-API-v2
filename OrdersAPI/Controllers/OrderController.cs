using Microsoft.AspNetCore.Mvc;
using OrdersAPI.Domain;
using OrdersAPI.Services.Interfaces;

namespace OrdersAPI.Controllers
{

    [Route("OrdersAPI/[Controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private IOrderService _OrderService;
        public OrderController(IOrderService OrderService)
        {
            _OrderService = OrderService;
        }
        [HttpGet]
        public List<Order> GetOrders()
        {
            return _OrderService.GetAll();
        }

        [HttpPost]
        public Order SaveOrder(Order Order)
        {
            return _OrderService.SaveOrder(Order);
        }

        [HttpDelete]
        public void DeleteOrder(int id)
        {
            _OrderService.RemoveOrder(id);
        }
    }
}
