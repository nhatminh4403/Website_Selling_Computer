using Microsoft.EntityFrameworkCore;
using Website_Selling_Computer.DataAccess;
using Website_Selling_Computer.Models;
using Website_Selling_Computer.Repositories.Interfaces;

namespace Website_Selling_Computer.Repositories.EntityFrameworks
{
    public class EFPayingMethod : IPayingMethod
    {
        private readonly WebsiteSellingComputerDbContext _context;
        public EFPayingMethod(WebsiteSellingComputerDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PaymentMethod>> GetAllAsync()
        {
            return await _context.PaymentMethods.ToListAsync();
        }
        public async Task<PaymentMethod> GetByIdAsync(int id)
        {
            return await _context.PaymentMethods.FirstOrDefaultAsync(i => i.PaymentMethodId == id);
        }
        public async   Task AddAsync(PaymentMethod payment)
        {
            _context.PaymentMethods.Add(payment);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(PaymentMethod payment)
        {
            _context.PaymentMethods.Update(payment);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var payment = await _context.PaymentMethods.FindAsync(id);
            if (payment!= null)
            {
                _context.PaymentMethods.Remove(payment);
                await _context.SaveChangesAsync();
            }
            return;
        }
    }
}
