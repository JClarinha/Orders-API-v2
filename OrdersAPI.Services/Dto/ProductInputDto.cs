using OrdersAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersAPI.Services.NewFolder
{
    internal class ProductInputDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Tax { get; set; }
        public string Unit { get; set; }
    }
}
