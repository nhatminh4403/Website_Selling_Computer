using Website_Selling_Computer.Models;

namespace Website_Selling_Computer.Repositories.Interfaces
{
    public interface IProductCategory
    {
        Task<IEnumerable<ProductCategory>> GetAllAsync();
        Task<ProductCategory> GetByIdAsync(int id);
        Task AddAsync(ProductCategory productCategory);
        Task UpdateAsync(ProductCategory productCategory);
        Task DeleteAsync(int id);
    }
}

