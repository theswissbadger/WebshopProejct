
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace M295_Project_V1._0.Models
{
    public class ProductAppContext : DbContext
    {
        public ProductAppContext(DbContextOptions<ProductAppContext> options)
        : base(options) {
            
        }
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
    }

}
