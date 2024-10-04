using OrdersAPI.Data.Context;
using OrdersAPI.Domain;
using OrdersAPI.Repositories.Interfaces;
using OrdersAPI.Services.Interfaces;

namespace OrdersAPI.Services.Implemntations
{
    public class ProductService : IProductService
    {
        private OrdersApiDBContext _ordersApiDBContext;
        private IProductRepository _productRepository;

        public ProductService(OrdersApiDBContext ordersApiDBContext, IProductRepository productRepository)
        {
            _ordersApiDBContext = ordersApiDBContext;
            _productRepository = productRepository;
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public Product SaveProduct(Product product)
        {
            bool productResult = _productRepository.GetAny(product.Id);

            if (!productResult)
            {
                product = _productRepository.Add(product);
            }
            else
            {
                product = _productRepository.Update(product);
            }

            _ordersApiDBContext.SaveChanges();

            return product;
        }

        public void RemoveProduct(int id)
        {
            Product productResult = _productRepository.GetById(id);

            if (productResult != null)
            {
                _productRepository.Remove(productResult);

                _ordersApiDBContext.SaveChanges();
            }
        }
    }
}
