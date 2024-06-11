using OrdersAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersAPI.Services.Interfaces
{
    public interface IOrderService
    {
        List<Order> GetAll();
        Order SaveOrder(Order order);
        void RemoveOrder(int id);

    }
}
