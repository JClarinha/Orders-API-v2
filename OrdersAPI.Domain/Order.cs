namespace OrdersAPI.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNum { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal Total { get; set; }
    }
}
