using Website_Selling_Computer.Models;
namespace Website_Selling_Computer.Repositories.Interfaces
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
