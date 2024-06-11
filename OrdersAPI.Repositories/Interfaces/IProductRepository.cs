using OrdersAPI.Domain;

namespace OrdersAPI.Repositories.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int id);
        Product Add(Product Product);
        Product Update(Product Product);
        void Remove(Product Product);
    }
}
