using Microsoft.EntityFrameworkCore;
using OrdersAPI.Domain;

namespace OrdersAPI.Data.Context
{
    public class OrdersApiDBContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost; database=OrdersDB; integrated security=true; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Customer>().HasKey(p => p.Name); => Alterar chave primaria!
            modelBuilder.Entity<Customer>().Property(p => p.Email).HasMaxLength(150);
            modelBuilder.Entity<Order>().Property(p => p.Total).HasPrecision(2);
        }
    }
}
