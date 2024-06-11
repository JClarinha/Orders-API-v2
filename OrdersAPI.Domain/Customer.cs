namespace OrdersAPI.Domain
{
    public class Customer 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nif { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }



        public override string ToString()
        {
            return $"Id: {Id}, Nome: {Name}, Nif: {Nif}, Email: {Email}, Phone: {Phone}";
        }





    }
}
