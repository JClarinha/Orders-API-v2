using Microsoft.AspNetCore.Mvc;
using OrdersAPI.Domain;
using OrdersAPI.Services.Interfaces;

namespace OrdersAPI.Controllers
{
    [Route("OrdersAPI/[Controller]")]
    [ApiController]    
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;            
        }          

        [HttpGet]
        public List<Category> GetCategories()
        {
            return _categoryService.GetAll();
        }

        [HttpPost]   
        public Category SaveCategory(Category category) 
        {
            return _categoryService.SaveCategory(category);   
        }

        [HttpDelete]
        public void DeleteCategory(int id)
        {
            _categoryService.RemoveCategory(id);
        }
    }
}
