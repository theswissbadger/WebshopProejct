
using M295_Project_V1._0.Models;

namespace M295_Project_V1._0.Data
{

    public class DbInitializer
    {
        private List<User> users = new List<User>
        {
            new User { 
                Name = "Fabio",
                Email = "ss",
                Password = "password"
            },
            new User
            {
                Name = "Dominic",
                Email = "Test@test.de",
                Password = "password"
            }
        };
        private List<Product> products = new List<Product>
        {
            new Product {
               // Id = 1,
                Image = "/pictures/product1.jpg",
                Title = "Razer Mamba",
                Description = "Mamba Gaming mouse",
                Price = 19.99f
            },


            new Product {
                // Id = 2,
                Image = "/pictures/product2.jpg",
                Title = "SteelSeries Arctis 7 Wireless",
                Description = "Over Ear Gaming Headset",
                Price = 110f
            },
            new Product {
                // Id = 3,
                Image = "/pictures/product3.jpg",
                Title = "HyperX CLoud 2",
                Description = "HyperX Gaming Headset, 7.1 Surroundsound",
                Price = 60.50f
            },
            new Product {
                // Id = 4,
                Image = "/pictures/product4.jpg",
                Title = "Intel Core i5-13600kf",
                Description = "LGA 1700, 3.50 GHz, 14 -Core",
                Price = 304f
            },
            new Product {
                // Id = 5,
                Image = "/pictures/product5.jpg",
                Title = "Razer Kitty Ears V2",
                Description = "For more drip ",
                Price = 22.99f
            }
        };

        private readonly ProductAppContext _context;
        public DbInitializer(ProductAppContext context)
        {
            _context = context;
        }
        public void Run()
        {
            if (_context.Database.EnsureCreated())
            {
                // add intial data (seed data)
                _context.Products.AddRange(products);
                // store everything to database
                _context.Users.AddRange(users);
                _context.SaveChanges();

            }
        }
    }
}
