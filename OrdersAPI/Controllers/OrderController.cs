using Microsoft.AspNetCore.Mvc;
using OrdersAPI.Domain;
using OrdersAPI.Services.Interfaces;

namespace OrdersAPI.Controllers
{

    [Route("OrdersAPI/[Controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public List<Order> GetAllOrders()
        {
            return _orderService.GetAll();
        }


        [HttpGet("{id}")]
        public Order GetById(int id)
        {
            return _orderService.GetById(id);
        }

        [HttpPost]
        public Order SaveOrder(Order order)
        {
            return _orderService.SaveOrder(order);
        }

        [HttpDelete("{id}")]
        public void DeleteOrder(int id)
        {
            _orderService.RemoveOrder(id);
        }
    }


}
