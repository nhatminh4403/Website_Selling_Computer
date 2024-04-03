using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Website_Selling_Computer.DataAccess;
using Website_Selling_Computer.Models;
using Website_Selling_Computer.Repositories.Interfaces;

namespace Website_Selling_Computer.Repositories.EntityFrameworks
{
    public class EFProductDetails : IProductDetails
    {
        private readonly WebsiteSellingComputerDbContext _context;  
        public EFProductDetails(WebsiteSellingComputerDbContext context)
        {
            _context = context;
        }
        public async Task<ProductDetail> GetProductDetailsByIdAsync(int id)
        {
            return _context.ProductDetails
            .Include(pd => pd.Product)
            .FirstOrDefault(pd => pd.ProductID ==id);
        }
    }
}
