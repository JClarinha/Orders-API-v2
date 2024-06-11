namespace OrdersAPI.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int Tax { get; set; }
        public string Unit { get; set; }
       
    }
}
