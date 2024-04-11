using Microsoft.EntityFrameworkCore;
using Website_Selling_Computer.DataAccess;
using Website_Selling_Computer.Models;
using Website_Selling_Computer.Repositories.Interfaces;
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
            return await _context.Manufacturers.FirstAsync(p => p.ManufacturerID == id);
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
            if (manufacturer != null)
            {
                _context.Manufacturers.Remove(manufacturer);
                await _context.SaveChangesAsync();
            }
            return;
        }

        public async Task<ICollection<Manufacturer>> FindByNameAsync(string name)
        {
            List<Manufacturer> manufacturers = await _context.Manufacturers.Where(p => p.ManufacturerName.Contains(name)).ToListAsync();
            return manufacturers;
        }
    }
}
