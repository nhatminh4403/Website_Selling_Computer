using Website_Selling_Computer.Models;

namespace Website_Selling_Computer.Repositories.Interfaces
{
    public interface IProductDetails
    {
        Task<ProductDetail> GetProductDetailsByIdAsync(int id);
    }
}
