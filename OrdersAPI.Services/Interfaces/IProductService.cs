using OrdersAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersAPI.Services.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product SaveProduct(Product product);
        void RemoveProduct(int id);
    }
}
