using Microsoft.EntityFrameworkCore;
using Website_Selling_Computer.DataAccess;
using Website_Selling_Computer.Models;
using Website_Selling_Computer.Repositories.Interfaces;
namespace Website_Selling_Computer.Repositories.EntityFrameworks
{
    public class EFProductCategory : IProductCategory
    {
        private readonly WebsiteSellingComputerDbContext _context;
        public EFProductCategory(WebsiteSellingComputerDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductCategory>> GetAllAsync()
        {
            return await _context.ProductCategories.ToListAsync();
        }
        public async Task<ProductCategory> GetByIdAsync(int id)
        {
            return await _context.ProductCategories.SingleAsync(x => x.CategoryID == id);
        }
        public async Task AddAsync(ProductCategory productCategory)
        {
            _context.ProductCategories.Add(productCategory);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(ProductCategory productCategory)
        {
            _context.ProductCategories.Update(productCategory);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var category = await _context.ProductCategories.FindAsync(id);
            if (category != null)
            {
                _context.ProductCategories.Remove(category);
                await _context.SaveChangesAsync();
            }
            return;
        }
    }
}
