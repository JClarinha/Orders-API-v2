using OrdersAPI.Domain;

namespace OrdersAPI.Repositories.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int id);
        bool GetAny(int id);
        Product Add(Product product);
        Product Update(Product product);
        void Remove(Product product);
    }
}

