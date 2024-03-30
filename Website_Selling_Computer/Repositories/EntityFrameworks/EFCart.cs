using Website_Selling_Computer.Models;
using Website_Selling_Computer.Repositories.Interfaces;
using Website_Selling_Computer.DataAccess;
using Microsoft.EntityFrameworkCore;
namespace Website_Selling_Computer.Repositories.EntityFrameworks
{
    public class EFCart : ICart
    {
        private  readonly WebsiteSellingComputerDbContext _context;
        public EFCart(WebsiteSellingComputerDbContext context) 
        { 
            _context = context;
        }
        public async Task<IEnumerable<Cart>> GetAllAsync()
        {
            return await _context.Carts.ToListAsync();
        }
        public async Task<Cart> GetByIdAsync(int id)
        {
            return await _context.Carts.SingleOrDefaultAsync(x => x.CartID == id);
        }
        public async Task AddAsync(Cart cart)
        {
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Cart cart)
        {
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var cart = await _context.Carts.FindAsync(id);
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();
        }
    }
}
