using Website_Selling_Computer.Models;
namespace Website_Selling_Computer.Repositories.Interfaces
{
    public interface ICart
    {
        Task<IEnumerable<Cart>> GetAllAsync();
        Task<Cart> GetByIdAsync(int id);
        Task AddAsync(Cart cart);
        Task UpdateAsync(Cart cart);
        Task DeleteAsync(int id);
    }
}
