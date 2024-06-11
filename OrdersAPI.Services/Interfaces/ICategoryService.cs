using OrdersAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersAPI.Services.Interfaces
{
    public interface ICategoryService

    {
        List<Category> GetAll();
        Category SaveCategory(Category category);
        void RemoveCategory(int id);

    }
}
