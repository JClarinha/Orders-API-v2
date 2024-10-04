using Microsoft.AspNetCore.Mvc;
using OrdersAPI.Domain;
using OrdersAPI.Services.Interfaces;

namespace OrdersAPI.Controllers
{
    [Route("OrdersAPI/[Controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> GetAllProducts()
        {
            return _productService.GetAll();
        }

        [HttpGet("{id}")]
        public Product GetById(int id)
        {
            return _productService.GetById(id);
        }

        [HttpPost]
        public Product SaveProduct(Product product)
        {
            return _productService.SaveProduct(product);
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            _productService.RemoveProduct(id);
        }
    }
}
