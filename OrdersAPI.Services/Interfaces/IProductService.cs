using OrdersAPI.Domain;

namespace OrdersAPI.Services.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int id);
        Product SaveProduct(Product product);
        void RemoveProduct(int id);
    }
}
