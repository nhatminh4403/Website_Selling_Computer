using Microsoft.EntityFrameworkCore;
using Website_Selling_Computer.DataAccess;
using Website_Selling_Computer.Models;
using Website_Selling_Computer.Repositories.Interfaces;

namespace Website_Selling_Computer.Repositories.EntityFrameworks
{
    public class EFOrder : IOrder
    {
        private readonly WebsiteSellingComputerDbContext _context;
        public EFOrder(WebsiteSellingComputerDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Order>> GetAllAsync()
        {

            return await _context.Orders
            .Include(p => p.User)
           .Include(p=>p.PaymentMethod)
            .ToListAsync();
        }
        public async Task<Order> GetByIdAsync(int id)
        {

            return await _context.Orders.Include(p => p.User)
                .Include(p => p.PaymentMethod).FirstAsync(p => p.OrderID == id);
        }
        public async Task AddAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
            return;
        }
        
    }
}
