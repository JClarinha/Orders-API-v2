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
        public List<Product> GetProducts()
        {
            return _productService.GetAll();
        }

        [HttpPost]   
        public Product SaveProduct(Product product) 
        {
            return _productService.SaveProduct(product);   
        }

        [HttpDelete]
        public void DeleteProduct(int id)
        {
            _productService.RemoveProduct(id);
        }
    }
}
