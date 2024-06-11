using OrdersAPI.Data.Context;
using OrdersAPI.Domain;
using OrdersAPI.Repositories.Interfaces;
using OrdersAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersAPI.Services.Implemntations
{
    public class ProductService : IProductService
    {
        private OrdersApiDBContext _ordersApiDBContext;  
        private IProductRepository _productRepository;


        public ProductService (OrdersApiDBContext ordersApiDBContext, IProductRepository productRepository)
        {
            _ordersApiDBContext = ordersApiDBContext;
            _productRepository = productRepository;
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product SaveProduct(Product product) 
        {
            Product productResult = _productRepository.GetById(product.Id);
            if (productResult == null) 
            { 
                _productRepository.Add(product);
            }
            else
            {
                product = _productRepository.Update(product);
            }

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
