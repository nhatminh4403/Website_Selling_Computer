using Website_Selling_Computer.Models;
namespace Website_Selling_Computer.Repositories.Interfaces
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
        Task<int> AddAsync(Product product);
        Task<ICollection<Product>> FindByNameAsync(string name);
        Task<ICollection<Product>> FindByCategoryAsync(int CategoryID);
        Task<ICollection<Product>> FindByManufacturerAsync(int ManufacturerID);
    }
}
