using Microsoft.AspNetCore.Mvc;
using OrdersAPI.Domain;
using OrdersAPI.Services.Interfaces;

namespace OrdersAPI.Controllers
{
    [Route("OrdersAPI/[Controller]")]
    [ApiController]
    public class OrderProductController : ControllerBase
    {
        private IOrderProductService _orderProductService;

        public OrderProductController(IOrderProductService orderProductService)
        {
            _orderProductService = orderProductService;
        }

        [HttpGet("{orderId}")]
        public List<OrderProduct> GetAllOrderProducts(int orderId)
        {
            return _orderProductService.GetAllByOrderId(orderId);
        }

        [HttpPost]
        public OrderProduct SaveOrderProduct(OrderProduct order)
        {
            return _orderProductService.SaveOrderProduct(order);
        }

        [HttpDelete("{id}")]
        public void DeleteOrderProduct(int id)
        {
            _orderProductService.RemoveOrderProduct(id);
        }
    }
}
