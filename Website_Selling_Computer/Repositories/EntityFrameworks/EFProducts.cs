using Microsoft.EntityFrameworkCore;
using Website_Selling_Computer.DataAccess;
using Website_Selling_Computer.Models;
using Website_Selling_Computer.Repositories.Interfaces;
namespace Website_Selling_Computer.Repositories.EntityFrameworks
{
    public class EFProducts : IProduct
    {
        private readonly WebsiteSellingComputerDbContext _context;
        public EFProducts(WebsiteSellingComputerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
            .Include(p => p.ProductCategory)
            .Include(p => p.Manufacturer)
            .Include(p => p.Inventories)
            .ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.Include(p => p.ProductCategory).Include(p => p.Manufacturer).FirstAsync(p => p.ProductID == id);
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.ProductID;
        }

        public async Task<ICollection<Product>> FindByNameAsync(string name)
        {
            List<Product> listProduct = await _context.Products
                .Where(p => p.ProductName != null && p.ProductName.Contains(name))
                .ToListAsync();
            return listProduct;
        }


        public async Task<ICollection<Product>> FindByCategoryAsync(int CategoryID)
        {
            List<Product> products = await _context.Products.Where(p => p.CategoryID == CategoryID).ToListAsync();
            return products;
        }

        public async Task<ICollection<Product>> FindByManufacturerAsync(int ManufacturerID)
        {
            List<Product> products = await _context.Products.Where(p => p.ManufacturerID == ManufacturerID).ToListAsync();
            return products;
        }
    }
}
