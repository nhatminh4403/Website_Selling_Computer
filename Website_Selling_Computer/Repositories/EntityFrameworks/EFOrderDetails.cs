using Microsoft.EntityFrameworkCore;
using Website_Selling_Computer.DataAccess;
using Website_Selling_Computer.Models;
using Website_Selling_Computer.Repositories.Interfaces;

namespace Website_Selling_Computer.Repositories.EntityFrameworks
{
    public class EFOrderDetails : IOrderDetails

    {   
        private readonly WebsiteSellingComputerDbContext _context;
        public EFOrderDetails(WebsiteSellingComputerDbContext context)
        {
            _context = context;
        }
        public async Task<OrderDetail> GetOrderDetailsByIdAsync(int id)
        {
            return await _context.OrderDetails.Include(p => p.Order).Include(p=>p.Product).FirstAsync(p=>p.OrderID ==id);
        }

    }
}
