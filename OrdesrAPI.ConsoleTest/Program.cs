using OrdersAPI.Data.Context;
using OrdersAPI.Domain;
using OrdersAPI.Repositories.Implementations;

namespace Tests
{
    public class Program
    {
        static void Main(string[] args)
        {

            OrdersApiDBContext ordersApiDBContext = new OrdersApiDBContext();
            CustomerRepository customerRepository = new CustomerRepository(ordersApiDBContext);
            CategoryRepository categoryRepository = new CategoryRepository(ordersApiDBContext);
            OrderRepository orderRepository = new OrderRepository(ordersApiDBContext);
            ProductRepository productRepository = new ProductRepository(ordersApiDBContext);
            OrderProductRepository orderproductRepository = new OrderProductRepository(ordersApiDBContext);



            while (true)
            {
                MenuIn();
                int imp = Convert.ToInt32(Console.ReadLine());


                if (imp == 6)
                {
                    break;
                }

                switch (imp)
                {
                    case 1:


                        while (true)
                        {
                            MenuCust();
                            int a = Convert.ToInt32(Console.ReadLine());

                            if (a == 5)
                            {
                                break;
                            }

                            switch (a)
                            {
                                case 1:
                                    Console.WriteLine();
                                    PrintCustomers(customerRepository);

                                    Customer c = new Customer();
                                    Console.WriteLine("Insert a Customer Name");
                                    c.Name = Console.ReadLine();
                                    Console.WriteLine("Insert a Customer Nif");
                                    c.Nif = Console.ReadLine();
                                    Console.WriteLine("Insert a Customer Email");
                                    c.Email = Console.ReadLine();
                                    Console.WriteLine("Insert a Customer Phone Number");
                                    c.Phone = Console.ReadLine();

                                    customerRepository.Add(c);
                                    break;

                                case 2:
                                    Console.WriteLine();
                                    PrintCustomers(customerRepository);
                                    Console.WriteLine("Insert the Id to be updated");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    Customer c2 = customerRepository.GetById(id);

                                    c2.Id = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Insert a new Customer Name");
                                    c2.Name = Console.ReadLine();
                                    Console.WriteLine("Insert a new Customer Nif");
                                    c2.Nif = Console.ReadLine();
                                    Console.WriteLine("Insert a new Customer Email");
                                    c2.Email = Console.ReadLine();
                                    Console.WriteLine("Insert a new Customer Phone Number");
                                    c2.Phone = Console.ReadLine();

                                    customerRepository.Update(c2);
                                    break;

                                case 3:
                                    PrintCustomers(customerRepository);

                                    Console.WriteLine("Insert the Id to be removed");
                                    int id2 = Convert.ToInt32(Console.ReadLine());
                                    Customer c3 = customerRepository.GetById(id2);
                                    customerRepository.Remove(c3);

                                    PrintCustomers(customerRepository);
                                    break;

                                case 4:
                                    PrintCustomers(customerRepository);
                                    break;

                                case 5:
                                    break;

                                default:

                                    Console.WriteLine("Invalid option");
                                    break;



                            }


                        }




                        break;

                    case 2:

                        while (true)
                        {
                            MenuCat();
                            int a = Convert.ToInt32(Console.ReadLine());

                            if (a == 5)
                            {
                                break;
                            }

                            switch (a)
                            {
                                case 1:
                                    Console.WriteLine();
                                    PrintCategories(categoryRepository);

                                    Category c = new Category();
                                    Console.WriteLine("Insert a Category Name");
                                    c.Name = Console.ReadLine();

                                    categoryRepository.Add(c);
                                    break;

                                case 2:
                                    Console.WriteLine();
                                    PrintCategories(categoryRepository);
                                    Console.WriteLine("Insert the Id to be updated");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    Category c2 = categoryRepository.GetById(id);

                                    c2.Id = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Insert a new Category Name");
                                    c2.Name = Console.ReadLine();

                                    categoryRepository.Update(c2);
                                    break;

                                case 3:
                                    PrintCategories(categoryRepository);

                                    Console.WriteLine("Insert the Id to be removed");
                                    int id2 = Convert.ToInt32(Console.ReadLine());
                                    Category c3 = categoryRepository.GetById(id2);
                                    categoryRepository.Remove(c3);

                                    PrintCategories(categoryRepository);
                                    break;

                                case 4:
                                    PrintCategories(categoryRepository);
                                    break;

                                case 5:
                                    break;

                                default:

                                    Console.WriteLine("Invalid option");
                                    break;

                            }

                        }

                        break;

                    case 3:

                        while (true)
                        {
                            MenuOrd();
                            int a = Convert.ToInt32(Console.ReadLine());

                            if (a == 5)
                            {
                                break;
                            }

                            switch (a)
                            {
                                case 1:
                                    Console.WriteLine();
                                    PrintOrders(orderRepository);

                                    Order c = new Order();
                                    Console.WriteLine("Insert a OrderNum");
                                    c.OrderNum = Console.ReadLine();
                                    Console.WriteLine("Insert an Order Date");
                                    c.OrderDate = Convert.ToDateTime(Console.ReadLine());
                                    Console.WriteLine("Insira um Customer Id");
                                    c.CustomerId = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Total");
                                    c.Total = Convert.ToDecimal(Console.ReadLine());

                                    orderRepository.Add(c);
                                    break;

                                case 2:
                                    Console.WriteLine();
                                    PrintOrders(orderRepository);
                                    Console.WriteLine("Insert the Id to be updated");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    Order c2 = orderRepository.GetById(id);

                                    c2.Id = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Insert a new Order Name");
                                    c2.OrderNum = Console.ReadLine();
                                    Console.WriteLine("Insert a new Order Date");
                                    c2.OrderDate = Convert.ToDateTime(Console.ReadLine());
                                    Console.WriteLine("Insert a Customer ID");
                                    c2.CustomerId = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Inser the Total Value");
                                    c2.Total = Convert.ToDecimal(Console.ReadLine());

                                    orderRepository.Update(c2);
                                    break;

                                case 3:
                                    PrintOrders(orderRepository);

                                    Console.WriteLine("Insert the Id to be removed");
                                    int id2 = Convert.ToInt32(Console.ReadLine());
                                    Order c3 = orderRepository.GetById(id2);
                                    orderRepository.Remove(c3);

                                    PrintOrders(orderRepository);
                                    break;

                                case 4:
                                    PrintOrders(orderRepository);
                                    break;

                                case 5:
                                    break;

                                default:

                                    Console.WriteLine("Invalid option");
                                    break;

                            }

                        }


                        break;

                    case 4:
                        while (true)
                        {
                            MenuProd();
                            int a = Convert.ToInt32(Console.ReadLine());

                            if (a == 5)
                            {
                                break;
                            }

                            switch (a)
                            {
                                case 1:
                                    Console.WriteLine();
                                    PrintProducts(productRepository);

                                    Product c = new Product();
                                    Console.WriteLine("Insert a Product Name");
                                    c.Name = Console.ReadLine();
                                    Console.WriteLine("Insert an Category Id");
                                    c.CategoryId = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Insert a Unit Price");
                                    c.UnitPrice = Convert.ToDecimal(Console.ReadLine());
                                    Console.WriteLine("Insert a Tax Value");
                                    c.Tax = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Insert a Unit");
                                    c.Unit = Console.ReadLine();
                                    productRepository.Add(c);
                                    break;

                                case 2:
                                    Console.WriteLine();
                                    PrintProducts(productRepository);
                                    Console.WriteLine("Insert the Id to be updated");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    Product c2 = productRepository.GetById(id);

                                    Console.WriteLine("Insert a Product Name");
                                    c2.Name = Console.ReadLine();
                                    Console.WriteLine("Insert an Category Id");
                                    c2.CategoryId = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Insert a Category");
                                    c2.UnitPrice = Convert.ToDecimal(Console.ReadLine());
                                    Console.WriteLine("Insert a Tax Value");
                                    c2.Tax = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Insert a Unit");
                                    c2.Unit = Console.ReadLine();

                                    productRepository.Update(c2);
                                    break;

                                case 3:
                                    PrintProducts(productRepository);

                                    Console.WriteLine("Insert the Id to be removed");
                                    int id2 = Convert.ToInt32(Console.ReadLine());
                                    Product c3 = productRepository.GetById(id2);
                                    productRepository.Remove(c3);

                                    PrintProducts(productRepository);
                                    break;

                                case 4:
                                    PrintProducts(productRepository);
                                    break;

                                case 5:
                                    break;

                                default:

                                    Console.WriteLine("Invalid option");
                                    break;

                            }

                        }

                        break;

                    case 5:
                        while (true)
                        {
                            MenuProdOrd();
                            int a = Convert.ToInt32(Console.ReadLine());

                            if (a == 4)
                            {
                                break;
                            }

                            switch (a)
                            {
                                case 1:
                                    Console.WriteLine();
                                    PrintProductsInOrders(orderproductRepository);

                                    OrderProduct c = new OrderProduct();
                                    Console.WriteLine("Insert a Product Id");
                                    c.ProductId = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Insert an Order Id");
                                    c.OrderId = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Insert a Unit Price");
                                    c.Unit = Console.ReadLine();
                                    Console.WriteLine("Insert a Qunataty");
                                    c.Qt = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Insert a Unit");
                                    c.Unit = Console.ReadLine();
                                    orderproductRepository.Add(c);
                                    break;

                                case 2:
                                    Console.WriteLine();
                                    PrintProductsInOrders(orderproductRepository);
                                    Console.WriteLine("Insert the Id to be updated");

                                    int id = Convert.ToInt32(Console.ReadLine());
                                    OrderProduct c2 = orderproductRepository.GetById(id);
                                    Console.WriteLine("Insert a Product Id");
                                    c2.ProductId = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Insert an Order Id");
                                    c2.OrderId = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Insert a Unit Price");
                                    c2.Unit = Console.ReadLine();
                                    Console.WriteLine("Insert a Qunataty");
                                    c2.Qt = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Insert a Unit");
                                    c2.Unit = Console.ReadLine();
                                    orderproductRepository.Add(c2);

                                    orderproductRepository.Update(c2);
                                    break;

                                case 3:
                                    PrintProductsInOrders(orderproductRepository);
                                    break;

                                case 4:
                                    break;

                                default:

                                    Console.WriteLine("Invalid option");
                                    break;

                            }

                        }

                        break;

                    case 6:
                        break;

                    default:
                        Console.WriteLine("Invalid Option");
                        break;


                }
            }


        }




        public static void PrintCustomers(CustomerRepository customerRepository)
        {


            List<Customer> customers = customerRepository.GetAll();

            foreach (var _dbSet in customers)
            {
                Console.WriteLine(_dbSet);

            }

        }


        public static void PrintCategories(CategoryRepository categoryRepository)
        {
            List<Category> category = categoryRepository.GetAll();

            foreach (var _dbSet in category)
            {
                Console.WriteLine(_dbSet);

            }
        }

        public static void PrintOrders(OrderRepository orderRepository)
        {
            List<Order> orders = orderRepository.GetAll();

            foreach (var _dbSet in orders)
            {
                Console.WriteLine(_dbSet);

            }
        }

        public static void PrintProducts(ProductRepository productRepository)
        {
            List<Product> products = productRepository.GetAll();

            foreach (var _dbSet in products)
            {
                Console.WriteLine(_dbSet);

            }
        }


        public static void PrintProductsInOrders(OrderProductRepository orderproductRepository)
        {
            List<OrderProduct> orderproducts = orderproductRepository.GetAll();

            foreach (var _dbSet in orderproducts)
            {
                Console.WriteLine(_dbSet);

            }
        }

        public static void MenuIn()
        {
            Console.WriteLine("====================================================");
            Console.WriteLine("Select what you want to do");
            Console.WriteLine("1 - Customers");
            Console.WriteLine("2 - Categories");
            Console.WriteLine("3 - Orders");
            Console.WriteLine("4 - Products");
            Console.WriteLine("5 - Products in Orders");
            Console.WriteLine("6 - Exit");
            Console.WriteLine("====================================================");
        }


        public static void MenuCust()
        {
            Console.WriteLine("====================================================");
            Console.WriteLine("1 - Add a Customer");
            Console.WriteLine("2 - Update a Customer");
            Console.WriteLine("3 - Remove a Customer");
            Console.WriteLine("4 - View a Customer");
            Console.WriteLine("5 - Exit");
            Console.WriteLine("====================================================");
        }


        public static void MenuCat()
        {
            Console.WriteLine("====================================================");
            Console.WriteLine("1 - Add a Category");
            Console.WriteLine("2 - Update a Category");
            Console.WriteLine("3 - Remove a Category");
            Console.WriteLine("4 - View a Category");
            Console.WriteLine("5 - Exit");
            Console.WriteLine("====================================================");
        }

        public static void MenuOrd()
        {
            Console.WriteLine("====================================================");
            Console.WriteLine("1 - Add a Orders");
            Console.WriteLine("2 - Update a Orders");
            Console.WriteLine("3 - Remove a Orders");
            Console.WriteLine("4 - View an Order");
            Console.WriteLine("5 - Exit");
            Console.WriteLine("====================================================");
        }

        public static void MenuProd()
        {
            Console.WriteLine("====================================================");
            Console.WriteLine("1 - Add a Products");
            Console.WriteLine("2 - Update a Products");
            Console.WriteLine("3 - Remove a Products");
            Console.WriteLine("4 - View a Product");
            Console.WriteLine("5 - Exit");
            Console.WriteLine("====================================================");
        }

        public static void MenuProdOrd()
        {
            Console.WriteLine("====================================================");
            Console.WriteLine("1 - Add a Product in an Order");
            Console.WriteLine("2 - Update a Product in an Order");
            Console.WriteLine("3 - View Products in Orders");
            Console.WriteLine("4 - Exit");
            Console.WriteLine("====================================================");
        }

    }
}
