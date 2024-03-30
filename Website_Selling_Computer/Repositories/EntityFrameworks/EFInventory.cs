using Website_Selling_Computer.Models;
using Website_Selling_Computer.Repositories.Interfaces;
using Website_Selling_Computer.DataAccess;
using Microsoft.EntityFrameworkCore;
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

            return await _context.Inventory
            .Include(p => p.Product)
            .Include(p=>p.Manufacturer)
            .ToListAsync();
        }
        public async Task<Inventory> GetByIdAsync(int id)
        {
            return await _context.Inventory
            .Include(p => p.Product)
            .Include(p => p.Manufacturer)
            .FirstOrDefaultAsync();
        }
        public async Task AddAsync(Inventory inventory)
        {
            _context.Inventory.Add(inventory);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Inventory inventory)
        {
            _context.Inventory.Update(inventory);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var inventory = await _context.Inventory.FindAsync(id);
            _context.Inventory.Remove(inventory);
            await _context.SaveChangesAsync();
        }
    }
}
