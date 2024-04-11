using Microsoft.EntityFrameworkCore;
using Website_Selling_Computer.DataAccess;
using Website_Selling_Computer.Models;
using Website_Selling_Computer.Repositories.Interfaces;
namespace Website_Selling_Computer.Repositories.EntityFrameworks
{
    public class EFInventory : I_Inventory
    {
        private readonly WebsiteSellingComputerDbContext _context;
        public EFInventory(WebsiteSellingComputerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Inventory>> GetAllAsync()
        {
            return await _context.Inventory.ToListAsync();
        }

        public async Task<Inventory> GetByIdAsync(int id)
        {
            return await _context.Inventory.FirstAsync(p => p.InventoryID == id);
        }

        public async Task UpdateAsync(Inventory inventory)
        {
            _context.Inventory.Update(inventory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var inventory = await _context.Inventory.FindAsync(id);
            if (inventory != null)
            {
                _context.Inventory.Remove(inventory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddAsync(Inventory inventory)
        {
            _context.Inventory.Add(inventory);
            await _context.SaveChangesAsync();
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
