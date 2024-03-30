using Microsoft.EntityFrameworkCore;

namespace Website_Selling_Computer.Models
{
    public class WebsiteSellingComputerDbContext : DbContext
    {
        public WebsiteSellingComputerDbContext(DbContextOptions<WebsiteSellingComputerDbContext> options) : base(options) { }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<ProductDetail> ProductDetails { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
