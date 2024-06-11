using OrdersAPI.Data.Context;
using OrdersAPI.Repositories.Implementations;
using OrdersAPI.Repositories.Interfaces;
using OrdersAPI.Services.Implementations;
using OrdersAPI.Services.Implemntations;
using OrdersAPI.Services.Interfaces;
using System.Reflection;

namespace OrdersAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            //Configuração do Serviço do Swagger
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    "OrdersAPI",
                    new Microsoft.OpenApiInfo()
                    {
                        Title = "Orders Api",
                        Version = "1.0"
                    });
            });


            //Registo da base de dados
            builder.Services.AddScoped<OrdersApiDBContext>();

            //registo de repositorios
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IOrderProductRepository, OrderProductRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            //Registo de serviços
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IOrderService, OrderService>();


            //Registo dos Controladores
            builder.Services.AddControllers();

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Configuração da Interface Gráfica Do Swagger
            app.UseSwagger().UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("OrdersAPI/Swagger.json", "Orders Api");
            });

            app.Run();
        }
    }
}
