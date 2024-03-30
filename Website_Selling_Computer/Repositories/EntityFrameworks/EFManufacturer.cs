using Website_Selling_Computer.Models;
using Website_Selling_Computer.Repositories.Interfaces;
using Website_Selling_Computer.DataAccess;
using Microsoft.EntityFrameworkCore;
namespace Website_Selling_Computer.Repositories.EntityFrameworks
{
    public class EFManufacturer : IManufacturer
    {
        private readonly WebsiteSellingComputerDbContext _context;
        public EFManufacturer(WebsiteSellingComputerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Manufacturer>> GetAllAsync()
        {
            return await _context.Manufacturers
            .ToListAsync();
        }
        public async Task<Manufacturer> GetByIdAsync(int id)
        {
            return await _context.Manufacturers.FirstOrDefaultAsync(p => p.ManufacturerID == id);
        }
        public async Task AddAsync(Manufacturer manufacturer)
        {
            _context.Manufacturers.Add(manufacturer);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Manufacturer manufacturer)
        {
            _context.Manufacturers.Update(manufacturer);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var manufacturer = await _context.Manufacturers.FindAsync(id);
            _context.Manufacturers.Remove(manufacturer);
            await _context.SaveChangesAsync();
        }

    }
}
