using Website_Selling_Computer.Models;

namespace Website_Selling_Computer.Repositories.Interfaces
{
    public interface IManufacturer
    {
        Task<IEnumerable<Manufacturer>> GetAllAsync();
        Task<Manufacturer> GetByIdAsync(int id);
        Task AddAsync(Manufacturer manufacturer);
        Task UpdateAsync(Manufacturer  manufacturer);
        Task DeleteAsync(int id);
        Task<ICollection<Manufacturer>> FindByNameAsync(string name);
    }
}
