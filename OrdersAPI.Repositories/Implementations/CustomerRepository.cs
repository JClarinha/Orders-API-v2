using OrdersAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data;
using OrdersAPI.Data.Context;
using OrdersAPI.Repositories.Interfaces;

namespace OrdersAPI.Repositories.Implementations
{
    public class CustomerRepository :ICustomerRepository
    {
        private readonly DbSet<Customer> _dbSet;
        private readonly OrdersApiDBContext _ordersApiDBContext;

        public CustomerRepository(OrdersApiDBContext ordersApiDBContext)
        {
            _dbSet = ordersApiDBContext.Set<Customer>();
            _ordersApiDBContext = ordersApiDBContext;


        }


        public List<Customer> GetAll()
        {
            return _dbSet.ToList(); // SELECT * FROM Customers;
        }

        public Customer GetById(int id)
        {
            return _dbSet.FirstOrDefault(p => p.Id == id); // SELECT * FROM Customers WHERE Id = ao imput 

        }


        public List<Customer> GetByName(string name)
        {
            return _dbSet.Where(p => p.Name.Contains(name)).ToList(); // SELECT * FROM Customers WHERE Name LIKE '%name%'
        }

        public Customer Add(Customer customer)
        {
            _dbSet.Add(customer); // INSERT INTO Customers (Collums) Values (Values)
            _ordersApiDBContext.SaveChanges();
            return customer;

        }


        public Customer Update(Customer customer)
        {
            _dbSet.Update(customer); // UPDATE Customers SET Collum = VALUE, ... , WHERE Id=Id
            _ordersApiDBContext.SaveChanges();
            return customer;

        }

        public void Remove(Customer customer)
        {
            _dbSet.Remove(customer); // DELET FROM Customers WHEERE Id = customer.Id
            _ordersApiDBContext.SaveChanges();


        }




    }
}
