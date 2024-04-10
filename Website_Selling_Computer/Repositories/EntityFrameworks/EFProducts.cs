using Website_Selling_Computer.Models;
using Website_Selling_Computer.Repositories.Interfaces;
using Website_Selling_Computer.DataAccess;
using Microsoft.EntityFrameworkCore;
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
            // return await _dbContext.Products.ToListAsync();
            return await _context.Products
            .Include(p => p.ProductCategory)
            .Include(p=> p.Manufacturer)
            .Include(p=>p.Inventories)
            .ToListAsync();
        }
        public async Task<Product> GetByIdAsync(int id)
        {
            // return await _context.Products.FindAsync(id);
            // lấy thông tin kèm theo category
            return await _context.Products.Include(p => p.ProductCategory).Include(p => p.Manufacturer).FirstOrDefaultAsync(p => p.ProductID == id);
        }
        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }

}
