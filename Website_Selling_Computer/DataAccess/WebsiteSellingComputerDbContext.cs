using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Website_Selling_Computer.Models;

namespace Website_Selling_Computer.DataAccess
{
    public class WebsiteSellingComputerDbContext : IdentityDbContext<User>
    {
        public WebsiteSellingComputerDbContext(DbContextOptions<WebsiteSellingComputerDbContext> options) : base(options) { }

        //       protected override void OnModelCreating(ModelBuilder modelBuilder)
        //       {
        //           base.OnModelCreating(modelBuilder);
        //
        //           modelBuilder.Entity<User>()
        //               .HasOne(u => u.Cart)
        //               .WithOne(c => c.User)
        //               .HasForeignKey<Cart>(c => c.UserID);
        //       }

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
